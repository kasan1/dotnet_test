using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Entities.Identity;
using Agro.Shared.Data.Enums.System;
using Agro.Shared.Logic.Common.Delegates;
using Agro.Shared.Logic.Common.Enums;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Models.System;
using Agro.Shared.Logic.Models.User.Profile;
using Agro.Shared.Logic.Services.System.File;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Agro.Shared.Logic.Services.System.User.Profile
{
    public class UserProfileService : IUserProfileService
    {
        #region Fields

        private readonly DataContext _dataContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IFileService _fileService;

        #endregion

        #region Constructor

        public UserProfileService(DataContext dataContext, 
            UserManager<AppUser> userManager,
            Delegates.FileServiceResolver fileServiceResolver)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _fileService = fileServiceResolver(FileServiceTypeEnum.Database);
        }

        #endregion

        #region Public functions

        public async Task<ProfileResult> Get(Guid userId, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.Users
                .Include(x => x.Profile)
                .SingleOrDefaultAsync(x => x.Id == userId, cancellationToken);

            if (user == null)
            {
                throw new RestException(HttpStatusCode.NotFound, "Пользователь не найден");
            }

            var image = (await _fileService.GetEntityFiles(EntityType.UserImage, userId)).FirstOrDefault();

            return GenerateProfile(user, image);
        }

        public async Task<ProfileResult> CreateOrUpdate(Guid userId, CreateProfileForm createProfileForm, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.Users
                .Include(x => x.Profile)
                .SingleOrDefaultAsync(x => x.Id == userId, cancellationToken);

            if (user == null)
            {
                throw new RestException(HttpStatusCode.NotFound, "Пользователь не найден");
            }

            FileMetaData image = null;
            if (createProfileForm.Image != null)
            {
                int maxSizeMb = 2;
                if (createProfileForm.Image.Length > maxSizeMb * 1024 * 1024)
                    throw new RestException(HttpStatusCode.BadRequest, $"Размер файла превышает норму в {maxSizeMb} МБ");

                var images = await _fileService.GetEntityFiles(EntityType.UserImage, userId);
                foreach (var img in images)
                {
                    await _fileService.RemoveAsync(img.Id);
                }

                image = await _fileService.UploadAsync(createProfileForm.Image, EntityType.UserImage, user.Id);
            }
            else
            {
                image = (await _fileService.GetEntityFiles(EntityType.UserImage, userId)).FirstOrDefault();
            }

            if (user.Email != createProfileForm.Email)
            {
                var emailSaveResult = await _userManager.SetEmailAsync(user, createProfileForm.Email);

                if (!emailSaveResult.Succeeded)
                {
                    throw new RestException(HttpStatusCode.BadRequest, string.Join(" ", emailSaveResult.Errors.Select(x => x.Description)));
                }

                // TODO: Add confirm email logic
            }

            if (user.PhoneNumber != createProfileForm.Phone)
            {
                var phoneNumberSaveResult =  await _userManager.SetPhoneNumberAsync(user, createProfileForm.Phone);

                if (!phoneNumberSaveResult.Succeeded)
                {
                    throw new RestException(HttpStatusCode.BadRequest, string.Join(" ", phoneNumberSaveResult.Errors.Select(x => x.Description)));
                }

                // TODO: Add confirm logic if needed from business
            }
            
            if (user.Profile == null)
            {
                user.Profile = new UserProfile
                {
                    UserId = userId,
                    Identifier = user.UserName
                };
            }

            user.Profile.FirstName = createProfileForm.FirstName;
            user.Profile.LastName = createProfileForm.LastName;
            user.Profile.Patronymic = createProfileForm.MiddleName;
            user.Profile.BirthDate = createProfileForm.BirthDate;
            user.Profile.CertificateStartDate = createProfileForm.CertificateStartDate ?? user.Profile.CertificateStartDate;
            user.Profile.CertificateEndDate = createProfileForm.CertificateEndDate ?? user.Profile.CertificateEndDate;

            await _dataContext.SaveChangesAsync(cancellationToken);

            return GenerateProfile(user, image);
        }

        #endregion

        #region Private functions

        private ProfileResult GenerateProfile(AppUser user, FileMetaData image)
        {
            return new ProfileResult
            {
                FirstName = user.Profile.FirstName,
                LastName = user.Profile.LastName,
                MiddleName = user.Profile.Patronymic,
                BirthDate = user.Profile.BirthDate,
                Identifier = user.Profile.Identifier,
                Email = user.Email,
                Phone = user.PhoneNumber,
                Image = image,
                CertificateStartDate = user.Profile.CertificateStartDate,
                CertificateEndDate = user.Profile.CertificateEndDate
            };
        }

        #endregion
    }
}
