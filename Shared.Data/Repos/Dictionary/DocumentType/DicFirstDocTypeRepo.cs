using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;

namespace Agro.Shared.Data.Repos.Dictionary.DocumentType
{
    public class DicFirstDocTypeRepo : BaseRepo<DicFirstDocType>, IDicFirstDocTypeRepo
    {
        public DicFirstDocTypeRepo(DataContext context) : base(context)
        {
        }
    }
}



