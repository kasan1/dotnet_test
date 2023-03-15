using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agro.Shared.Data.Repos
{
    public interface IAppActives: IBaseRepo<Context.AppActives>
    {
        Task<Data.Context.AppActives> GetClientAppActivesTask(Guid id);
    }
}
