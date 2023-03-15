using Agro.Shared.Data;
using Agro.Shared.Data.Primitives;
using Agro.Shared.Data.Repos.User;
using Agro.Shared.Logic.Models;
using Camunda.Api.Client;
using Camunda.Api.Client.History;
using Camunda.Api.Client.Message;
using Camunda.Api.Client.ProcessDefinition;
using Camunda.Api.Client.ProcessInstance;
using Camunda.Api.Client.UserTask;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agro.Shared.Logic.Camunda
{
    public class ProcessLogic : IProcessLogic
    {
        private readonly CamundaClient _client;
        private readonly IOptions<AppSettings> _options;

        public ProcessLogic(IOptions<AppSettings> options)
        {
            _client = CamundaClient.Create(options.Value.Camunda.Url);
            _options = options;
        }

        public async Task<string> StartProcessAsync(LoanApplicationInDto model)
        {
            //код бизнес-процесса в Camunda
            string processDefinitionKey = model.LoanType switch
            {
                LoanTypeEnum.StandartLeasing => _options.Value.Camunda.StandardProcessKey,
                LoanTypeEnum.ExpressLeasing => _options.Value.Camunda.ExpressProcessKey,
                _ => "Leasing"
            };

            try
            {
                StartProcessInstance startProcessInstance = new StartProcessInstance();

                // Variables
                Dictionary<string, VariableValue> vars = new Dictionary<string, VariableValue>
                {
                    { "ApplicationId", VariableValue.FromObject(model.ApplicationId.ToString()) },
                    { "bpmUrl", VariableValue.FromObject(_options.Value.Camunda.BpmUrl) },
                    { "delegateToCompliance", VariableValue.FromObject(model.NeedComplianceChecking ? "1": "0") },
                    { "committeeCount", VariableValue.FromObject(model.CountOfCommitteeMembers) },
                    { "delegateByCreditCommittee5", VariableValue.FromObject("1") } //для случая, когда CreditCommittee5 не участвует в процессе
                };
                startProcessInstance.Variables = vars;

                //Запуск заявки по ProcessDefinitionKey
                var taskStartProcess = await _client.ProcessDefinitions.ByKey(processDefinitionKey).StartProcessInstance(startProcessInstance);

                return taskStartProcess.Id;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<UserTaskInfo> GetTasksByQuery(TaskQuery taskQuery)
        {
            //Получение списка задач, назначенных на пользовтеля
            // taskQuery = new TaskQuery { superProcessInstance = processDefinitionKey, Assignee = "CredCom1Code" }.Sort(TaskSorting.Created, SortOrder.Descending);
            var tasks = await _client.UserTasks.Query(taskQuery).List();
            if (tasks.Count == 0)
                throw new Exception("Заявка не найдена в Camunda");
            return tasks.FirstOrDefault();
        }

        /// <summary>
        /// Получение списка задач
        /// </summary>
        /// <param name="taskQuery"></param>
        /// <returns></returns>
        private async Task<List<UserTaskInfo>> UserTasks(TaskQuery taskQuery)
        {
            return await _client.UserTasks.Query(taskQuery).List();
        }

        /// <summary>
        /// Завершить задачу
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="vars"></param>
        /// <returns></returns>
        public async Task TaskComplete(Guid taskId, Dictionary<string, object> vars)
        {
            var variables = new Dictionary<string, VariableValue> { };
            foreach (var key in vars.Keys)
                variables.Add(key, VariableValue.FromObject(vars[key]));

            await _client.UserTasks.CompleteTask(taskId.ToString(), new CompleteTask
            {
                Variables = variables
            }); 
        }

        /// <summary>
        /// история маршрута
        /// </summary>
        /// <param name="histQuery"></param>
        /// <returns></returns>
        public async Task<List<HistoricActivityInstance>> HistoryAsync(HistoricActivityInstanceQuery histQuery)
        {
            var client = CamundaClient.Create("http://10.2.2.245:8080/engine-rest");
            return await client.History.ActivityInstances.Query(histQuery).List();
        }

        /// <summary>
        /// Отправка сообщения
        /// </summary>
        /// <returns></returns>
        public async Task DeliverMessage(string processInstanceId, string scoringResult)
        {
            var histQuery = new HistoricActivityInstanceQuery { ProcessInstanceId = processInstanceId }.Sort(HistoricActivityInstanceQuerySorting.StartTime, SortOrder.Ascending);
            var histProcessInstanceId = await HistoryAsync(histQuery);
            var activityInstance = histProcessInstanceId.Where(m => m.ActivityType == "callActivity" && m.ActivityId == "FinancialAnalysis" && m.EndTime == DateTime.MinValue).First();
            var message = new CorrelationMessage
            {
                ProcessInstanceId = activityInstance.CalledProcessInstanceId,
                MessageName = "MessageScoringResponse",
                All = false
            };
            message.ProcessVariables.Set("ScoringResult", scoringResult);
            Task taskGroup = DeliverMessage(message);
            taskGroup.Wait();
        }

        /// <summary>
        /// Отправка сообщения
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private async Task DeliverMessage(CorrelationMessage message)
        {
            var client = CamundaClient.Create("http://10.2.2.245:8080/engine-rest");
            await client.Messages.DeliverMessage(message);
        }

        public async Task DeleteProcessAsync(Guid processId)
        {
            var info = await _client.ProcessInstances.Delete(new DeleteProcessInstances
            {
                ProcessInstanceIds = new List<string> { processId.ToString() }
            });

            Console.Write(info.CreateUserId);
        }
    }
}
