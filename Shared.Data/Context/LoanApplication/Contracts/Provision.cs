using Agro.Shared.Data.Entities.Base;
using Agro.Shared.Data.Entities.Dictionaries;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agro.Shared.Data.Context
{
    public class Provision : BaseEntity
    {
        public Guid ContractId { get; set; }
        [ForeignKey(nameof(ContractId))]
        public Contract Contract { get; set; }

        public Guid? ProvisionTypeId { get; set; }
        [ForeignKey(nameof(ProvisionTypeId))]
        public DicProvisionType ProvisionType { get; set; }

        public Guid? ProvisionDescriptionId { get; set; }
        [ForeignKey(nameof(ProvisionDescriptionId))]
        public DicProvisionDescription ProvisionDescription { get; set; }
        public decimal? Sum { get; set; }

    }
}
