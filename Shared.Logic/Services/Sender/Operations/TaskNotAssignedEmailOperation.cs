using System;

namespace Agro.Shared.Logic.Services.Sender.Operations
{
    public class TaskNotAssignedEmailOperation : BaseEmailOperation
    {
        private static readonly string _template = @"
            <div>
                <header>
                    <h1>Внимание! Задача не была присвоена пользователю.</h1>
                </header>
                <section>
                    <p>Для задачи с идентификатором <b>'{0}'</b> не найден соответствующий пользователь с кодом роли <b>'{1}'</b>. 
                        Пожалуйста переназначте задачу другому пользователю вручную.</p>
                </section>
            </div>
        ";

        public TaskNotAssignedEmailOperation(Guid taskId, string roleName) : base("BPM задача не присвоена", string.Format(_template, taskId, roleName))
        {
        }
    }
}
