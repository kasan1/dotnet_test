namespace Agro.Shared.Logic.Services.Sender.Operations
{
    public class ResetPasswordEmailOperation : BaseEmailOperation
    {
        private static readonly string _template = @"
            <div>
                <header>
                    <h3>Вы пытаетесь восстановить пароль.</h3>
                </header>
                <section>
                    <p>Для восстановления пароля пожалуйста пройдите <a href='{resetLink}'>по ссылке</a>.</p>
                </section>
            </div>
        ";

        public ResetPasswordEmailOperation(string resetLink) : base("Восстановление пароля", _template.Replace("{resetLink}", resetLink))
        {
        }
    }
}
