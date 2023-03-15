using Agro.Shared.Logic.Models;
using Camunda.Api.Client;
using Camunda.Api.Client.History;
using Camunda.Api.Client.UserTask;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agro.Shared.Logic.Camunda
{
    public interface IProcessLogic
    {
        Task<string> StartProcessAsync(LoanApplicationInDto model);
        Task<List<HistoricActivityInstance>> HistoryAsync(HistoricActivityInstanceQuery histQuery);
        Task DeliverMessage(string processInstanceId, string scoringResult);
        Task TaskComplete(Guid taskId, Dictionary<string, object> vars);
        Task<UserTaskInfo> GetTasksByQuery(TaskQuery taskQuery);
        Task DeleteProcessAsync(Guid processId);
    }
}