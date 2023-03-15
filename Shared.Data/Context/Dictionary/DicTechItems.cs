using System;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context.Dictionary
{
    public class DicTechItems:BaseDictionary
    {
        public Guid? DicTechTypeId { get; set; }
        public DicTechType TechType { get; set; }
        public Guid? DicTechClassTypesId { get; set; }
 
        /*public DicTechItems(BaseDictionary parent) : base(parent)
        {
        }*/
    }
}