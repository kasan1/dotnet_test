using Agro.Okaps.Logic.Models;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Primitives;
using Agro.Shared.Data.Repos.Branch;
using Agro.Shared.Data.Repos.Client;
using Agro.Shared.Data.Repos.LoanApplication;
using Agro.Shared.Data.Repos.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agro.Okaps.Logic
{
    public class ClientProfileLogic : IClientProfileLogic
    {
        private readonly IClientProfileRepo _clientProfileRepo;
        private readonly IUserRepo _userRepo;
        private readonly IBranchRepo _branchRepo;
        



        public ClientProfileLogic(IClientProfileRepo clientProfileRepo, IUserRepo userRepo, IBranchRepo branchRepo)
        {
            _clientProfileRepo = clientProfileRepo;
            _userRepo = userRepo;
            _branchRepo = branchRepo;
        }

        public async Task<object> GetClientProfileByID(Guid UserId)
        {
            //var res = await _clientProfileRepo
            //    .Base()
            //    .AsNoTracking()
            //    .Select(x => new
            //    {
            //        x.Id,
            //        x.UserId,
            //        x.Gender,
            //        x.MaritalStatus,
            //        x.RegistrationAddressKz,
            //        x.ChildrenCount,
            //        x.RegistrationAddressRu,
            //        x.DocumentOrganizationName,
            //        x.DocumentNumber,
            //        x.DocumentEndDate,
            //        x.DocumentBeginDate,

            //        x.CompanyNdc,
            //        x.CompanyName,
            //        x.CompanyAddress,
            //        x.CompanyActivity,
            //        x.CompanyRegisterDate,
            //        x.CompanyRegisterNumber,
            //        x.CompanySerialNumber,
            //        x.ClientTypeId,
            //        ClientType = x.DicClientType != null ? x.DicClientType.NameRu : null,

            //        FullName = x.User.FullName,
            //        Iin = x.User.Identifier,
            //        x.BirthPlaceRu,
            //        x.User.Phone,
            //        x.User.AdditionPhone,
            //        x.User.BirthDate,
            //        Filial = ""
            //    })
            //    .SingleOrDefaultAsync(x => x.UserId == UserId);

            //if (res != null) return res;

            //var profile = new ClientProfile
            //{
            //    UserId = UserId,
            //    Gender = Gender.Male,
            //    MaritalStatus = MaritalStatusEnum.Single
            //};

            //await _clientProfileRepo.Add(profile);
            //return await GetClientProfileByID(profile.Id);
            throw new NotImplementedException();
        }

        public async Task<bool> CheckExistsByUserId(Guid userId)
        {
            return await _clientProfileRepo.GetQueryable(x => x.UserId == userId).AnyAsync();
        }

        public async Task<Guid> AddClientProfile(ClientProfileInDto model)
        {
            var CliProfile = new ClientProfile
            {
                BirthPlaceRu = model.BirthPlaceRu,
                BirthPlaceKz = model.BirthPlaceKz,
                RegistrationAddressRu = model.RegistrationAddressRu,
                RegistrationAddressKz = model.RegistrationAddressKz,
                Gender = model.Gender,
                MaritalStatus = model.MaritalStatus,
                ChildrenCount = model.ChildrenCount,
                DocumentTypeName = model.DocumentTypeName,
                DocumentOrganizationName = model.DocumentOrganizationName,
                DocumentNumber = model.DocumentNumber,
                DocumentBeginDate = model.DocumentBeginDate,
                DocumentEndDate = model.DocumentEndDate,
                UserId = model.UserId
            };

            return await _clientProfileRepo.Add(CliProfile);
        }

        public async Task UpdateClientProfile(ClientProfileInDto model)
        {
            var res = await _clientProfileRepo.GetQueryable(x => x.UserId == model.UserId).FirstOrDefaultAsync();
            res.BirthPlaceRu = model.BirthPlaceRu;
            res.BirthPlaceKz = model.BirthPlaceKz;
            res.RegistrationAddressRu = model.RegistrationAddressRu;
            res.RegistrationAddressKz = model.RegistrationAddressKz;
            res.Gender = model.Gender;
            res.MaritalStatus = model.MaritalStatus;
            res.ChildrenCount = model.ChildrenCount;
            res.DocumentTypeName = model.DocumentTypeName;
            res.DocumentOrganizationName = model.DocumentOrganizationName;
            res.DocumentNumber = model.DocumentNumber;
            res.DocumentBeginDate = model.DocumentBeginDate;
            res.DocumentEndDate = model.DocumentEndDate;

            res.ClientTypeId = model.ClientTypeId;
            res.CompanyName = model.CompanyName;
            res.CompanyActivity = model.CompanyActivity;
            res.CompanySerialNumber = model.CompanySerialNumber;
            res.CompanyRegisterNumber = model.CompanyRegisterNumber;
            res.CompanyRegisterDate = model.CompanyRegisterDate;
            res.CompanyAddress = model.CompanyAddress;
            res.CompanyNdc = model.CompanyNdc;

            await _clientProfileRepo.Save();
        }
        public async Task UpdateClientProfileInfo(ClientProfileInDto model)
        {
            var res = await _clientProfileRepo.GetQueryable(x => x.UserId == model.UserId).FirstOrDefaultAsync();

            res.ClientTypeId = model.ClientTypeId;
            res.CompanyName = model.CompanyName;
            res.CompanyActivity = model.CompanyActivity;
            res.CompanySerialNumber = model.CompanySerialNumber;
            res.CompanyRegisterNumber = model.CompanyRegisterNumber;
            res.CompanyRegisterDate = model.CompanyRegisterDate;
            //res.CompanyAddress = model.CompanyAddress;
            res.CompanyNdc = model.CompanyNdc;

            await _clientProfileRepo.Save();
        }

        public async Task<object> GetBranchAdressByClientId(Guid Userid)
        {
            //var branchId = _userRepo.GetById(Userid).Result.BranchId;
            var branchId = Guid.Empty;
            var branchAdresses = await _branchRepo.Base()
                .AsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.NameKz,
                    x.NameRu,
                    x.AddressKz,
                    x.AddressRu
                })
                .SingleOrDefaultAsync(x => x.Id == branchId);

            return branchAdresses;
        }
    }
}
