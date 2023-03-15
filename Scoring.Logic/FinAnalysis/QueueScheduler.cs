using Agro.Shared.Data.Extensions;
using Agro.Shared.Data.Repos.FinAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agro.Scoring.Logic.FinAnalysis
{
    public class QueueScheduler : IQueueScheduler
    {
        private readonly IFinAnalysisQueueTaskRepo _repo;
        private readonly IFinAnalysisLogic _logic;
        public QueueScheduler(IFinAnalysisQueueTaskRepo repo, IFinAnalysisLogic logic)
        {
            _repo = repo;
            _logic = logic;
        }

        public async Task FindTask()
        {
            var _ = await _repo.GetQueryable(x => !x.IsDeleted && x.Status == Shared.Data.Primitives.QueueTaskType.New)
                .AsNoTracking()
                .Select(x => x)
                .OrderBy(x => x.CreatedDate)
                .FirstOrDefaultAsync();
            //foreach(var i in _)
            //{
            if (_ == default)
                return;
            try
            {
                Console.WriteLine("Start");
                _.Status = Shared.Data.Primitives.QueueTaskType.InWork;
                await _repo.Update(_);
                var task = _logic.Start(_.ApplicationId).Wait(-1);
                _.Status = Shared.Data.Primitives.QueueTaskType.Complete;
                await _repo.Update(_);
            }
            catch (Exception e)
            {
                _.Status = Shared.Data.Primitives.QueueTaskType.Error;
                await _repo.Update(_);
            }
            //}
        }
    }
}
