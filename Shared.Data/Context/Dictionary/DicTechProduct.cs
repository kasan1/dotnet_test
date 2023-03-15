using System;
using System.Collections.Generic;
using System.Text;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context.Dictionary
{
    public class DicTechProduct : BaseDictionary
    {
        public Guid DicTechTypeId { get; set; }
        public DicTechType DicTechType { get; set; }
        public Guid? DicAccessoriesId { get; set; }
        public DicAccessories DicAccessories { get; set; }
        public ICollection<DicTechModel> DicTechModels { get; set; }
        public DicTechProduct()
        {
            DicTechModels = new List<DicTechModel>();
        }
    }
}
