using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Entities.Identity;
using Agro.Shared.Data.Enums.Identity;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Common.Options;
using Agro.Shared.Logic.Models.User.Identity;
using Agro.Shared.Logic.Services.Sender;
using Agro.Shared.Logic.Services.Sender.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Agro.Shared.Logic.Services.System.User.Identity
{
    public class IdentityService : IIdentityService
    {
        #region Fields

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly DataContext _dataContext;
        private readonly JwtOptions _jwtOptions;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly ISenderService _emailSenderService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly string _hostUrl;

        #endregion

        #region Contructor

        public IdentityService(UserManager<AppUser> userManager,
                               RoleManager<AppRole> roleManager,
                               DataContext dataContext,
                               JwtOptions jwtOptions,
                               TokenValidationParameters tokenValidationParameters,
                               ISenderService emailSenderService,
                               IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dataContext = dataContext;
            _jwtOptions = jwtOptions;
            _tokenValidationParameters = tokenValidationParameters;
            _emailSenderService = emailSenderService;
            _httpContextAccessor = httpContextAccessor;

            _hostUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
        }

        #endregion

        #region Public functions

        public async Task<AuthenticationResult> ChangePasswordAsync(string username, string currentPassword, string newPassword)
        {
            var user = await _userManager.Users
                .Include(x => x.Profile)
                .SingleOrDefaultAsync(x => x.UserName == username);

            if (user == null)
            {
                throw new RestException(HttpStatusCode.NotFound, "Пользователь не найден");
            }

            var passwordChangeResult = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

            if (!passwordChangeResult.Succeeded)
            {
                throw new RestException(HttpStatusCode.BadRequest, string.Join(" ", passwordChangeResult.Errors.Select(x => x.Description)));
            }

            return await GenerateAuthenticationResultForUserAsync(user);
        }

        public async Task SendResetPasswordTokenAsync(string username)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == username);

            if (user == null)
            {
                throw new RestException(HttpStatusCode.BadRequest, "Пользователь не найден");
            }

            if (string.IsNullOrEmpty(user.Email))
            {
                throw new RestException(HttpStatusCode.BadRequest, "У вашего пользователя не узказана электронная почта");
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                throw new RestException(HttpStatusCode.BadRequest, "Вы не подтвердили электронную почту");
            }

            await SendResetPasswordEmail(user);
        }

        public async Task<AuthenticationResult> LoginAsync(string username, string password)
        {
            var user = await _userManager.Users
                .Include(x => x.Profile)
                .SingleOrDefaultAsync(x => x.UserName == username);

            if (user == null)
            {
                throw new RestException(HttpStatusCode.BadRequest, "Неверный логин или пароль");
            }

            if (await _userManager.IsLockedOutAsync(user))
            {
                // TODO: Send email to the user to inform about possible attack
                throw new RestException(HttpStatusCode.BadRequest, "Пользователь заблокирован. Пожалуйста обратитесь к администратору");
            }

            var hasValidPassword = await _userManager.CheckPasswordAsync(user, password);

            if (!hasValidPassword)
            {
                await _userManager.AccessFailedAsync(user);

                throw new RestException(HttpStatusCode.BadRequest, "Неверный логин или пароль", true);
            }

            await _userManager.ResetAccessFailedCountAsync(user);

            return await GenerateAuthenticationResultForUserAsync(user);
        }

        public async Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken)
        {
            var principal = GetPrincipalFromToken(token);

            if (principal == null)
            {
                throw new RestException(HttpStatusCode.Unauthorized, "Невалидный токен");
            }

            var expiryDateUnix = long.Parse(principal.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
            var expiryDateTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(expiryDateUnix);

            if (expiryDateTimeUtc > DateTime.UtcNow)
            {
                throw new RestException(HttpStatusCode.BadRequest, "Срок действия токена еще не истекло");
            }

            var jti = principal.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
            var storedRefreshToken = await _dataContext.RefreshTokens.SingleOrDefaultAsync(x => x.Token == Guid.Parse(refreshToken));

            if (storedRefreshToken == null)
            {
                throw new RestException(HttpStatusCode.BadRequest, "Указанного токена обновления не существует");
            }

            if (storedRefreshToken.ExpirationDate < DateTime.UtcNow)
            {
                throw new RestException(HttpStatusCode.BadRequest, "Срок действия токена обновления истек");
            }

            if (storedRefreshToken.JwtId != jti)
            {
                throw new RestException(HttpStatusCode.BadRequest, "Указанный токен обновления не соответствует указанному JWT");
            }

            var user = await _userManager.Users
                .Include(x => x.Profile)
                .SingleOrDefaultAsync(x => x.Id == storedRefreshToken.UserId);

            _dataContext.RefreshTokens.Remove(storedRefreshToken);
            await _dataContext.SaveChangesAsync();

            return await GenerateAuthenticationResultForUserAsync(user);
        }

        public async Task<AuthenticationResult> RegisterAsync(UserRegisterForm userRegisterForm, bool skipPassword = false)
        {
            if (!skipPassword)
            {
                if (!userRegisterForm.Password.Equals(userRegisterForm.ConfirmPassword))
                {
                    throw new RestException(HttpStatusCode.BadRequest, "Подтверждение пароля не совпадает с паролем");
                }
            }

            if (userRegisterForm.Email.IsNullOrEmpty())
            {
                throw new RestException(HttpStatusCode.BadRequest, "Необходимо указать электронную почту");
            }

            var user = await _userManager.Users
                .Include(x => x.Profile)
                .SingleOrDefaultAsync(x => x.UserName == userRegisterForm.Username);

            if (user != null)
            {
                throw new RestException(HttpStatusCode.BadRequest, "Пользователь с такими данными уже есть в системе");
            }

            var newUser = new AppUser
            {
                Id = Guid.NewGuid(),
                UserName = userRegisterForm.Username,
                Email = userRegisterForm.Email,
                UserAudienceType = userRegisterForm.UserAudienceType,
                EssenceType = userRegisterForm.EssenceType
            };

            if (!userRegisterForm.PhoneNumber.IsNullOrEmpty())
            {
                newUser.PhoneNumber = $"8{userRegisterForm.PhoneNumber}";
            }

            IdentityResult createdResult;
            if (skipPassword)
            {
                createdResult = await _userManager.CreateAsync(newUser);

                await SendSetPasswordEmail(newUser);
            }
            else
            {
                createdResult = await _userManager.CreateAsync(newUser, userRegisterForm.Password);
            }

            if (!createdResult.Succeeded)
            {
                throw new RestException(HttpStatusCode.BadRequest, string.Join(" ", createdResult.Errors.Select(x => x.Description)));
            }

            await AddToRoles(userRegisterForm, newUser);

            if (userRegisterForm.UserAudienceType == UserAudienceType.Ext)
            {
                await SendEmailConfirmationEmail(newUser);
            }

            return await GenerateAuthenticationResultForUserAsync(newUser);
        }

        public async Task ResetPasswordAsync(string username, string token, string newPassword)
        {
            var user = await _userManager.Users
                .Include(x => x.Profile)
                .SingleOrDefaultAsync(x => x.UserName == username);

            if (user == null)
            {
                throw new RestException(HttpStatusCode.NotFound, "Пользователь не найден");
            }

            var passwordResetResult = await _userManager.ResetPasswordAsync(user, token, newPassword);

            if (!passwordResetResult.Succeeded)
            {
                throw new RestException(HttpStatusCode.BadRequest, string.Join(" ", passwordResetResult.Errors.Select(x => x.Description)));
            }
        }

        public async Task ConfirmEmail(string userName, string token)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(x => x.UserName == userName);

            if (user == null)
            {
                throw new RestException(HttpStatusCode.BadRequest, "Пользователь не найден");
            }

            var confirmEmailResult = await _userManager.ConfirmEmailAsync(user, token);

            if (!confirmEmailResult.Succeeded)
            {
                throw new RestException(HttpStatusCode.BadRequest, string.Join(" ", confirmEmailResult.Errors.Select(x => x.Description)));
            }
        }

        #endregion

        #region Private functions

        private async Task<AuthenticationResult> GenerateAuthenticationResultForUserAsync(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);

            var claims = new List<Claim>
            {
                new Claim("userId", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName),
                new Claim(JwtRegisteredClaimNames.Aud, user.UserAudienceType.ToString()),
                new Claim(JwtRegisteredClaimNames.Iss, _jwtOptions.Issuer),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // It's required field, but we have some users who don't have it
            if (!string.IsNullOrEmpty(user.Email))
            {
                claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            }

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(_jwtOptions.TokenLifetime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var refreshToken = new RefreshToken
            {
                Token = Guid.NewGuid(),
                JwtId = token.Id,
                UserId = user.Id,
                CreatedDate = DateTime.UtcNow,
                ExpirationDate = DateTime.UtcNow.AddMonths(6)
            };

            _dataContext.RefreshTokens.Add(refreshToken);
            await _dataContext.SaveChangesAsync();

            return new AuthenticationResult
            {
                UserId = user.Id,
                DisplayName = user.Profile?.GetFullName(),
                AccessToken = tokenHandler.WriteToken(token),
                RefreshToken = refreshToken.Token.ToString()
            };
        }

        private ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var tokenValidationParameters = _tokenValidationParameters.Clone();

                tokenValidationParameters.ValidateLifetime = false;

                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);

                if (!IsJwtWithValidSecurityAlgorithm(validatedToken))
                {
                    return null;
                }

                return principal;
            }
            catch
            {
                return null;
            }
        }

        private bool IsJwtWithValidSecurityAlgorithm(SecurityToken securityToken)
        {
            return securityToken is JwtSecurityToken jwtSecurityToken &&
                jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
        }

        private async Task AddToRoles(UserRegisterForm userRegisterForm, AppUser user)
        {
            var roles = new List<string>();
            foreach (var roleId in userRegisterForm.Roles)
            {
                var role = await _roleManager.FindByIdAsync(roleId.ToString());
                if (role == null)
                {
                    throw new RestException(HttpStatusCode.BadRequest, "Роль не найдена в системе");
                }
                
                roles.Add(role.Name);
            }

            if (roles.Any())
            {
                await _userManager.AddToRolesAsync(user, roles);
            }
        }

        private async Task SendSetPasswordEmail(AppUser user)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = $"{_hostUrl}/password/set?username={user.UserName}&token={token}";
            var emailOperation = new SetPasswordEmailOperation(callbackUrl);
            var message = emailOperation.GetMessage(new List<string>() { user.Email });

            _emailSenderService.Send(message);
        }

        private async Task SendResetPasswordEmail(AppUser user)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = $"{_hostUrl}/password/reset?username={user.UserName}&token={token}";
            var emailOperation = new ResetPasswordEmailOperation(callbackUrl);
            var message = emailOperation.GetMessage(new List<string>() { user.Email });

            _emailSenderService.Send(message);
        }

        private async Task SendEmailConfirmationEmail(AppUser user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = $"{_hostUrl}/email/confirm?username={user.UserName}&token={token}";
            var emailOperation = new EmailConfirmationEmailOperation(callbackUrl);
            var message = emailOperation.GetMessage(new List<string>() { user.Email });

            _emailSenderService.Send(message);
        }

        #endregion
    }
}
