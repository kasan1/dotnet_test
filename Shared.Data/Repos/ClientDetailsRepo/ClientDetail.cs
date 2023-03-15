using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Repos.LoanApplication;
using Microsoft.EntityFrameworkCore;

namespace Agro.Shared.Data.Repos.ClientDetailsRepo
{
    public class ClientDetail : BaseRepo<Context.ClientDetails>, IClientDetail
    {
        private readonly DataContext _context;
        public ClientDetail(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Data.Context.ClientDetails> GetClientDetailsTask(Guid id)
        {
            return null;
        }
    }
}
