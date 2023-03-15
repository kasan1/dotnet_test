using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using Microsoft.EntityFrameworkCore;

namespace Agro.Shared.Data.Repos.Dictionary.Accessories
{
    public class AccessoriesRepo:BaseRepo<DicAccessories>,IAccessoriesRepo
    {
        private readonly DataContext _context;
        public AccessoriesRepo(DataContext context):base(context)
        {
            _context = context;
        }

        public async Task<List<DicAccessories>> GetAccessoriesByTechTypeId(string id)
        {
            return await _context.DicAccessorieses.Include(s => s.DicTechType).Where(s => s.DicTechType.Code == id)
                .ToListAsync();
        }
    }
}
