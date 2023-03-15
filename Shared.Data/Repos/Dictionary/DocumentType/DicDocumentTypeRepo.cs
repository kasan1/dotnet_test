using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.Dictionary.DocumentType
{
    public class DicDocumentTypeRepo : BaseRepo<DicDocumentType>, IDicDocumentTypeRepo
    {
        public DicDocumentTypeRepo(DataContext context) : base(context)
        {
        }
    }
}
