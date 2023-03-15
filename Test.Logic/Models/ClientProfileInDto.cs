using Agro.Shared.Data.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Agro.Okaps.Logic.Models
{
    public class ClientProfileInDto
    {
        public string BirthPlaceRu { get; set; }
        public string BirthPlaceKz { get; set; }
        public string RegistrationAddressDistrictCode { get; set; }
        public string RegistrationAddressRegionCode { get; set; }
        public string RegistrationAddressRu { get; set; }
        public string RegistrationAddressKz { get; set; }
        public Gender Gender { get; set; }
        public MaritalStatusEnum MaritalStatus { get; set; }
        public int ChildrenCount { get; set; }

        /// <summary>
        /// Номер удостоверения личности
        /// </summary>
        public string DocumentTypeName { get; set; }
        public string DocumentOrganizationName { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime? DocumentBeginDate { get; set; }
        public DateTime? DocumentEndDate { get; set; }

        public Guid UserId { get; set; }

        public Guid? ClientTypeId { get; set; }

        [MaxLength(200)]
        public string CompanyName { get; set; }

        [MaxLength(200)]
        public string CompanyActivity { get; set; }

        [MaxLength(200)]
        public string CompanySerialNumber { get; set; }

        public DateTime? CompanyRegisterDate { get; set; }

        [MaxLength(200)]
        public string CompanyRegisterNumber { get; set; }

        [MaxLength(400)]
        public string CompanyAddress { get; set; }
        public bool CompanyNdc { get; set; }

        public long? Level1 { get; set; }
        public long? Level2 { get; set; }
        public long? Level3 { get; set; }
        public long? Level4 { get; set; }
        public long? Level5 { get; set; }

        [MaxLength(100)]
        public string Cato { get; set; }
        public long? GeonimId { get; set; }
        public long? AtsId { get; set; }

        public Guid? ClientCategoryId { get; set; }
        public Guid? BankId { get; set; }
        public string BankAccount { get; set; }
        public Guid? ApplicationTaskId { get; set; }
    }
}
