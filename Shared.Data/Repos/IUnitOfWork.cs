using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Repos.Branch;

namespace Agro.Shared.Data.Repos
{
    public interface IUnitOfWork
    {
        DataContext GetContext();
        IBranchRepo BranchRepository { get; }

        Task Commit();
        Task RejectChanges();
        void Dispose();
    }
}