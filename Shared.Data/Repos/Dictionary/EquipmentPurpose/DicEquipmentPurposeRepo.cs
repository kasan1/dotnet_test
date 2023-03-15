using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.Dictionary.EquipmentPurpose
{
    public class DicEquipmentPurposeRepo : BaseRepo<DicEquipmentPurpose>, IDicEquipmentPurposeRepo
    {
        public DicEquipmentPurposeRepo(DataContext context) : base(context)
        {
        }
    }
}
