using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Entities.Base;
using Agro.Shared.Data.Entities.Identity;
using Agro.Shared.Data.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Agro.Shared.Data.Context
{
    public class ClientProfile : BaseEntity
    {
        public string BirthPlaceRu { get; set; }
        public string BirthPlaceKz { get; set; }
        public string RegistrationAddressDistrictCode { get; set; }
        public string RegistrationAddressRegionCode { get; set; }
        public string RegistrationAddressRu { get; set; }
        public string RegistrationAddressKz { get; set; }
        public Gender Gender { get; set; }
        public MaritalStatusEnum MaritalStatus { get; set; }
        /// <summary>
        /// Количество детей до 18 лет
        /// </summary>
        public int ChildrenCount { get; set; }
        /// <summary>
        /// Номер удостоверения личности
        /// </summary>
        public string DocumentTypeName { get; set; }
        public string DocumentOrganizationName { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime? DocumentBeginDate { get; set; }
        public DateTime? DocumentEndDate { get; set; }

        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; }
        public Guid UserId { get; set; }


        [ForeignKey(nameof(ClientTypeId))]
        public DicClientType DicClientType { get; set; }
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
    }
}
