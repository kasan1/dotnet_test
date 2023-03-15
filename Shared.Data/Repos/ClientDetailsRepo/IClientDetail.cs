using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agro.Shared.Data.Repos.ClientDetailsRepo
{
    public interface IClientDetail:IBaseRepo<Context.ClientDetails>
    {
        Task<Data.Context.ClientDetails> GetClientDetailsTask(Guid id);
    }
}
