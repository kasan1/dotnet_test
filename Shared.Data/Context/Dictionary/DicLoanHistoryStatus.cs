using System;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Shared.Data.Entities.Base;
using Agro.Shared.Data.Entities.Dictionaries;

namespace Agro.Shared.Data.Context.Dictionary
{
    public class DicLoanHistoryStatus: BaseDictionaryDerived
    {
        public DicLoanHistoryStatus()
        {
        }

        public DicLoanHistoryStatus(BaseDictionary parent) : base(parent)
        {
        }

        public Guid? StatusId { get; set; }

        [ForeignKey(nameof(StatusId))]
        public DicApplicationStatus DicApplicationStatus { get; set; }
    }
}
