using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Repos.LandActivy;
using Microsoft.EntityFrameworkCore;

namespace Agro.Shared.Data.Repos
{
    public class AppActives : BaseRepo<Context.AppActives>, IAppActives
    {
        private readonly DataContext _context;
        public AppActives(DataContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Data.Context.AppActives> GetClientAppActivesTask(Guid id)
        {
            return null;
        }
    }
}
