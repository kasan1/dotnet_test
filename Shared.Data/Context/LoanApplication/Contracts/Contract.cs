using System;
using System.Collections.Generic;
using Agro.Shared.Data.Entities.Base;
using Agro.Shared.Data.Entities.Dictionaries;
using Agro.Shared.Data.Entities.Identity;

namespace Agro.Shared.Data.Context
{
    public class Contract : BaseEntity
    {
        public string Number { get; set; }

        /// <summary>
        /// Предмет лизинга
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Остаток основного долга
        /// </summary>
        public decimal PrincipalDebtBalance { get; set; }

        public Guid? StatusId { get; set; }
                
        public Guid? LoanApplicationId { get; set; }
        public LoanApplication LoanApplication { get; set; }

        public Guid UserId { get; set; }
        public AppUser User { get; set; }

        public virtual DicContractStatus DicContractStatus { get; set; }
        public virtual Calculator Calculator { get; set; }
        public virtual SelectedTechnic SelectedTechnic { get; set; }
        public virtual List<SelectedAccessory> SelectedAccessories { get; set; } = new List<SelectedAccessory>();
        public virtual List<Provision> Provisions { get; set; }

    }
}
