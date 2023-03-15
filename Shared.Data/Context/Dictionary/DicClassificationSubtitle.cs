using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context.Dictionary
{
    public class DicClassificationSubtitle:BaseDictionary
    {

        [ForeignKey(nameof(DocClassificationId))]
        public DicDocClassification DocClassification { get; set; }
        public Guid DocClassificationId { get; set; }   
        public int ParagraphNumber { get; set; }
    }
}
