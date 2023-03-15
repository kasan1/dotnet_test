using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    public class Organization : BaseEntity
    {
        public Guid PersonalityId { get; set; }
        [ForeignKey(nameof(PersonalityId))]
        public Personality Personality { get; set; }

        public Guid? OrganizationTypeId { get; set; }
        [ForeignKey(nameof(OrganizationTypeId))]
        public DicOrganizationType DicOrganizationType { get; set; }

        public Guid? OwnershipFormId { get; set; }
        [ForeignKey(nameof(OwnershipFormId))]
        public DicOwnershipForm DicOwnershipForm { get; set; }


        /// <summary>
        /// Налоговый режим
        /// </summary>
        public Guid? TaxTreatmentId { get; set; }
        [ForeignKey(nameof(TaxTreatmentId))]
        public DicTaxTreatment DicTaxTreatment { get; set; }

        /// <summary>
        /// Организационно-правовая форма
        /// </summary>
        public Guid? LegalFormId { get; set; }
        [ForeignKey(nameof(LegalFormId))]
        public DicOrganizationAndLegalForm DicOrganizationAndLegalForm { get; set; }

        /// <summary>
        /// Субъект Предпринимательства
        /// </summary>
        public Guid? SubjectOfEntrepreneurId { get; set; }
        [ForeignKey(nameof(SubjectOfEntrepreneurId))]
        public DicSubjectOfEntrepreneur DicSubjectOfEntrepreneur { get; set; }

        public string Parent { get; set; }

        public bool IsAffiliated { get; set; }

        public Guid? AffiliatedOrganizatonId { get; set; }

        /// <summary>
        /// доля в уставном капитале
        /// </summary>
        public decimal? ShareInCapital { get; set; }

        public virtual ICollection<OrganizationOKED> OKED { get; set; }

        public DateTime? RegisteredDate { get; set; }

        public bool IsNewRegistered()
        {
            return RegisteredDate.HasValue & (DateTime.Now - RegisteredDate.Value).TotalDays < 90;
        }

        #region Temporary fields to store organization head info

        public string HeadIdentifier { get; set; }
        public string HeadFullName { get; set; }

        #endregion

    }
}
