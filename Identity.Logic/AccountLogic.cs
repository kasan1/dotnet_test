using Agro.Identity.Logic.Models;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Enums.Identity;
using Agro.Shared.Data.Enums.System;
using Agro.Shared.Data.Repos.User;
using Agro.Shared.Logic.Common.Delegates;
using Agro.Shared.Logic.Common.Enums;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.CQRS.Files.DTOs;
using Agro.Shared.Logic.Models.System;
using Agro.Shared.Logic.Services.System.File;
using Microsoft.EntityFrameworkCore;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Agro.Identity.Logic
{
    public class AccountLogic : IAccountLogic
    {
        private readonly IUserRepo _userRepo;
        private readonly IIdentityLogic _identityLogic;
        private readonly IFileService _fileService;

        public AccountLogic(IUserRepo userRepo, IIdentityLogic identityLogic, Delegates.FileServiceResolver fileServiceResolver)
        {
            _userRepo = userRepo;
            _identityLogic = identityLogic;
            _fileService = fileServiceResolver(FileServiceTypeEnum.Database);
        }

        #region Public functions

        public async Task<AuthResult> Login(LoginInDto dto)
        {
            var user = await _userRepo
                .GetQueryable(x => x.Identifier == dto.Login && !x.IsDeleted)
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync();
            if (user == default)
                throw new RestException(HttpStatusCode.BadRequest, "Неверный логин и(или) пароль");

            if (user.IsBlocked)
                throw new RestException(HttpStatusCode.BadRequest, "Пользователь заблокирован, обратитесь к администратору");

            var pwdhash = HashPwd(dto.Password);
            if (user.Password != pwdhash)
            {
                user.PasswordTryCount++;
                if (user.PasswordTryCount >= 5)
                    user.IsBlocked = true;
                await _userRepo.Update(user);

                throw new RestException(HttpStatusCode.BadRequest, "Неверный логин и(или) пароль");
            }

            user.PasswordTryCount = 0;

            var accessToken = _identityLogic.GenerateAccessToken(user);
            var refreshToken = _identityLogic.GenerateRefreshToken(user);

            user.RefreshToken = refreshToken;
            await _userRepo.Update(user);
            return new AuthResult
            {
                DisplayName = $"{user.LastName} {user.FirstName} {user.MiddleName}".Trim(),
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        public async Task<AuthResult> UpdateToken(string jwtToken, string refToken)
        {
            var decoded = _identityLogic.DecodeToken(jwtToken);
            if (decoded == default)
                throw new RestException(HttpStatusCode.Unauthorized, "Не авторизован");

            var value = decoded.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;
            if (value == default || !Guid.TryParse(value, out Guid userId))
                throw new RestException(HttpStatusCode.Unauthorized, "Не авторизован");

            var user = await _userRepo.GetQueryable(x => x.Id == userId)
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync();
            if (user == default)
                throw new RestException(HttpStatusCode.BadRequest, "Неверный логин и(или) пароль");

            if (_identityLogic.TokenExpired(refToken) || user.RefreshToken != refToken)
                throw new RestException(HttpStatusCode.Unauthorized, "Не авторизован");

            var accessToken = _identityLogic.GenerateAccessToken(user);
            var refreshToken = _identityLogic.GenerateRefreshToken(user);
            user.RefreshToken = refreshToken;
            await _userRepo.Update(user);
            return new AuthResult
            {
                DisplayName = $"{user.LastName} {user.FirstName} {user.MiddleName}".Trim(),
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        public async Task<Guid> Register(AdditionRegisterInDto model, bool IsPhysical)
        {
            if (IsPhysical)
            {
                var _ = model as PhysicalRegisterInDto;
                var result = await _userRepo.GetQueryable(x => x.Identifier == _.IIN)
                .AsNoTracking()
                .FirstOrDefaultAsync();
                if (result != default)
                    throw new RestException(HttpStatusCode.BadRequest, "Данный пользователь уже зарегистрирован в системе");

                var user = new User
                {
                    Identifier = _.IIN,
                    LastName = _.LastName,
                    FirstName = _.FirstName,
                    MiddleName = _.MiddleName,
                    BirthDate = _.BirthDate,
                    Password = HashPwd(_.Password),
                    Audience = UserAudienceType.Ext,
                    Phone = _.PhoneNumber,
                    IsPhysical = IsPhysical,
                };
                return await _userRepo.Add(user);
            }
            else
            {
                var _ = model as JuridicalRegisterInDto;
                var result = await _userRepo.GetQueryable(x => x.Identifier == _.BIN)
                .AsNoTracking()
                .FirstOrDefaultAsync();

                if (result != default)
                    throw new RestException(HttpStatusCode.BadRequest, "Данный пользователь уже зарегистрирован в системе");

                var user = new User
                {
                    Identifier = _.BIN,
                    CompanyName = _.CompanyName,
                    Password = HashPwd(_.Password),
                    Audience = UserAudienceType.Ext,
                    Phone = _.PhoneNumber,
                    IsPhysical = IsPhysical
                };
                return await _userRepo.Add(user);
            }
        }

        public async Task UpdateBranchId(Guid userId, Guid branchId)
        {
            //var user = await _userRepo.GetById(userId);
            //user.BranchId = branchId;
            //await _userRepo.Update(user);
            throw new NotImplementedException();
        }

        public async Task<bool> GetByIdentifier(string identifier)
        {
            var _ = await _userRepo.GetQueryable(x => x.Identifier == identifier && !x.IsDeleted).CountAsync();
            return _ > 0;
        }

        public async Task<ProfileDto> UpdateProfile(Guid userId, UpdateProfileDto profile, CancellationToken cancellationToken)
        {
            var user = await _userRepo.GetQueryable(x => x.Id == userId).FirstOrDefaultAsync(cancellationToken);
            if (user == null)
                throw new RestException(HttpStatusCode.NotFound, "Пользователь не найден");

            FileMetaData image = null;
            if (profile.Image != null)
            {
                int maxSizeMb = 2;
                if (profile.Image.Length > maxSizeMb * 1024 * 1024)
                    throw new RestException(HttpStatusCode.BadRequest, $"Размер файла превышает норму в {maxSizeMb} МБ");

                var images = await _fileService.GetEntityFiles(EntityType.UserImage, userId);
                foreach (var img in images)
                {
                    await _fileService.RemoveAsync(img.Id);
                }

                image = await _fileService.UploadAsync(profile.Image, EntityType.UserImage, user.Id);
            } else
            {
                image = (await _fileService.GetEntityFiles(EntityType.UserImage, userId)).FirstOrDefault();
            }

            user.FirstName = profile.Firstname ?? user.FirstName;
            user.LastName = profile.Lastname ?? user.LastName;
            user.MiddleName = profile.Middlename ?? user.MiddleName;
            user.BirthDate = profile.BirthDate ?? user.BirthDate;
            user.Email = profile.Email;
            user.Phone = profile.Phone;

            await _userRepo.Update(user);

            return MakeProfile(user, image);
        }

        public async Task<bool> ChangePassword(Guid userId, ChangePasswordDto passwordDto, CancellationToken cancellationToken)
        {
            var user = await _userRepo.GetQueryable(x => x.Id == userId).FirstOrDefaultAsync(cancellationToken);
            if (user == null)
                throw new RestException(HttpStatusCode.NotFound, "Пользователь не найден");

            if (HashPwd(passwordDto.OldPassword) != user.Password)
            {
                user.PasswordTryCount++;
                if (user.PasswordTryCount >= 5)
                    user.IsBlocked = true;
                await _userRepo.Update(user);

                throw new RestException(HttpStatusCode.BadRequest, "Неверно введен пароль");
            }

            if (passwordDto.NewPassword != passwordDto.ConfirmedNewPassword)
                throw new RestException(HttpStatusCode.BadRequest, "Неверно введено подтверждение нового пароля");

            user.Password = HashPwd(passwordDto.NewPassword);
            user.PasswordTryCount = 0;
            await _userRepo.Update(user);
            return true;
        }

        public async Task<ProfileDto> GetProfile(Guid userId, CancellationToken cancellationToken)
        {
            var user = await _userRepo.GetQueryable(x => x.Id == userId).FirstOrDefaultAsync(cancellationToken);
            if (user == null)
                throw new RestException(HttpStatusCode.NotFound, "Пользователь не найден");

            var images = await _fileService.GetEntityFiles(EntityType.UserImage, userId);

            return MakeProfile(user, images.FirstOrDefault());
        }

        #endregion

        #region Private functions

        private string HashPwd(string pwd)
        {
            var alg = SHA512.Create();
            alg.ComputeHash(Encoding.UTF8.GetBytes(pwd));
            return Convert.ToBase64String(alg.Hash);
        }

        private ProfileDto MakeProfile(User user, FileMetaData fileMetaData)
        {
            return new ProfileDto
            {
                Firstname = user.FirstName,
                Lastname = user.LastName,
                Middlename = user.MiddleName,
                BirthDate = user.BirthDate,
                Email = user.Email,
                Phone = user.Phone,
                Image = fileMetaData != null ? new FileDto
                {
                    Id = fileMetaData.Id,
                    Filename = fileMetaData.Filename,
                    Url = fileMetaData.Path
                } : null
            };
        }

        #endregion

    }
}
