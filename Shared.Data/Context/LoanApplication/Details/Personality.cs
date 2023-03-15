using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    public class Personality : BaseEntity
    {
        public string Identifier { get; set; }
        public string FullName { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }

        public Guid? PhoneId { get; set; }
        [ForeignKey(nameof(PhoneId))]
        public Phone Phone { get; set; }

        public Guid? AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        public Address Address { get; set; }

        public Guid? WorkExperienceId { get; set; }
        [ForeignKey(nameof(WorkExperienceId))]
        public WorkExperience WorkExperience { get; set; }

        /// <summary>
        /// Место регистрации
        /// </summary>
        public Guid? RegionId { get; set; }
        [ForeignKey(nameof(RegionId))]
        public DicRegion DicRegion { get; set; }

        /// <summary>
        /// Кредитная история
        /// </summary>
        public virtual ICollection<CreditHistory> CreditHistory { get; set; }

        /// <summary>
        /// Счета
        /// </summary>
        public virtual ICollection<BankAccount> BankAccounts { get; set; }

        /// <summary>
        /// задолженности
        /// </summary>
        public virtual ICollection<Dept> Depts { get; set; }

        public virtual ICollection<PersonalityDocument> Documents { get; set; }

        public string ShortFullname()
        {
            var shortName = "";
            var parts = FullName.Trim().Split(" ");
            foreach (var (namePart, index) in parts.Select((p, index) => (p, index)))
            {
                if (index > 2)
                    break;

                if (index == 0)
                {
                    shortName += $"{namePart} ";
                }
                else if (namePart.Length > 0)
                {
                    shortName += $"{namePart[0]}.";
                }
            }
            return shortName;
        }
    }
}
