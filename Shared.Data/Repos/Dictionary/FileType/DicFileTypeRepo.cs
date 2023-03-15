using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.Dictionary.FileType
{
    public class DicFileTypeRepo : BaseRepo<DicFileType>, IDicFileTypeRepo
    {
        public DicFileTypeRepo(DataContext context) : base(context)
        {
        }
    }
}
