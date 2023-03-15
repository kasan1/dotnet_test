using System;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context.Dictionary
{
    public class DicWarningClassification:BaseDictionary
    {
        [ForeignKey(nameof(ClassificationSubtitleId))]
        public DicClassificationSubtitle ClassificationSubtitle { get; set; }
        public Guid ClassificationSubtitleId { get; set; }
        
    }
}
