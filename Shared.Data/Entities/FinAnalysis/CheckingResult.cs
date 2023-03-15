using Agro.Shared.Data.Context.LoanApplications;
using Agro.Shared.Data.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agro.Shared.Data.Entities.FinAnalysis
{
    /// <summary>
    /// результаты проверки по внутренним спискам
    /// </summary>
    public class CheckingResult : BaseEntity
    {
        public Guid DetailsPersonalityId { get; set; }
        
        [ForeignKey(nameof(DetailsPersonalityId))]
        public DetailsPersonality DetailsPersonality { get; set; }

        public Guid CheckingListId { get; set; }

        [ForeignKey(nameof(CheckingListId))]
        public CheckingList CheckingList { get; set; }
    }
}
