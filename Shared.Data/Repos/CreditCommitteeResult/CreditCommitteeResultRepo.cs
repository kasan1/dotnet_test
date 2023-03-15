using Agro.Shared.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agro.Shared.Data.Repos.CreditCommitteeResult
{
    public class CreditCommitteeResultRepo : BaseRepo<Context.CreditCommitteeResult>, ICreditCommitteeResultRepo
    {
        public CreditCommitteeResultRepo(DataContext context) : base(context)
        {
        }

        //public async Task<List<object>> GetDecision(Guid appId)
        //{

        //    var res = base.GetQueryable(x => x.ApplicationId == appId)
        //    .Join(ContextBase.Users,
        //    c => c.UserId,
        //    u => u.Id,
        //    (c, u) => new
        //    {

        //        ApplicationId = c.ApplicationId,
        //        Accept = c.Accept,
        //        FullName = u.FullName,
        //        UserId = u.Id
        //    })
        //    .Select(x => new
        //    {
        //        ApplicationId = x.ApplicationId,
        //        Accept = x.Accept,
        //        FullName = x.FullName,
        //        UserId = x.UserId
        //    })
        //    .ToListAsync();

        //    return await res;
        //}
    }
}
