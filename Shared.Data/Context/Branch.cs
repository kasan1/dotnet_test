using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Entities.Base;
using Agro.Shared.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agro.Shared.Data.Context
{
    public class Branch : BaseEntity
    {
        /// <summary>
        /// ParentId
        /// </summary>
        [ForeignKey(nameof(ParentId))]
        public Branch ParentBranch { get; set; }
        public Guid? ParentId { get; set; }
        public string Code { get; set; }
        /// <summary>
        /// Наименование на казахском
        /// </summary>
        public string NameKz { get; set; }
        /// <summary>
        /// Наименование на русском
        /// </summary>
        public string NameRu { get; set; }
        /// <summary>
        /// Код КАТО
        /// </summary>
        public string CodeKato { get; set; }
        /// <summary>
        /// Код ГБДФЛ
        /// </summary>
        public string CodeGBDFL { get; set; }
        /// <summary>
        /// Код OCA
        /// </summary>
        public string CodeOCA { get; set; }
        /// <summary>
        /// БИН
        /// </summary>
        public string Bin { get; set; }
        /// <summary>
        /// адрес на казахском
        /// </summary>
        public string AddressKz { get; set; }
        /// <summary>
        /// адрес на русском
        /// </summary>
        public string AddressRu { get; set; }
        /// <summary>
        /// Контактный телефон  
        /// </summary>
        public string Phone { get; set; }
       
        [ForeignKey(nameof(RegionId))]
        public DicRegion Region { get; set; }
        public Guid? RegionId { get; set; }

        public Guid? AlterBranchId { get; set; }

        /// <summary>
        /// Список филиалов
        /// </summary>
        public virtual ICollection<UserBranch> Users { get; private set; }
    }
}
