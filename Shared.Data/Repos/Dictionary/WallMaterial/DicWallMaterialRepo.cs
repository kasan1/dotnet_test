using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.Dictionary.WallMaterial
{
    public class DicWallMaterialRepo : BaseRepo<DicWallMaterial>, IDicWallMaterialRepo
    {
        public DicWallMaterialRepo(DataContext context) : base(context)
        {
        }
    }

}
