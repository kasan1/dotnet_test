using Agro.Shared.Data.Entities.Dictionaries;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agro.Shared.Data.Entities.FinAnalysis
{
    /// <summary>
    /// общая таблица для внутренних списков 
    /// </summary>
    public class CheckingList : BaseCheckItem
    {
        public string Description { get; set; }

        public Guid TypeId { get; set; }

        [ForeignKey(nameof(TypeId))]
        public DicCheckingListType DicCheckingListType { get; set; }
    }
}
