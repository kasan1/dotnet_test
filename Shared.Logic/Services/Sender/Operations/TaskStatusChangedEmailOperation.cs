namespace Agro.Shared.Logic.Services.Sender.Operations
{
    public class TaskStatusChangedEmailOperation : BaseEmailOperation
    {
        public TaskStatusChangedEmailOperation(string subject, string content) : base(subject, content)
        {
        }
    }
}
