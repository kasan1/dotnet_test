namespace Agro.Shared.Logic.Services.Sender.Operations
{
    public class SetPasswordEmailOperation : BaseEmailOperation
    {
        private static readonly string _template = @"
            <div>
                <header>
                    <h3>Вы зарегистрированы в системе Казагрофинанс БПМ.</h3>
                </header>
                <section>
                    <p>Пожалуйста пройдите <a href='{resetLink}'>по ссылке</a> чтобы завершить регистрацию и установить пароль.</p>
                </section>
            </div>
        ";

        public SetPasswordEmailOperation(string resetLink) : base("Подтверждение регистрации", _template.Replace("{resetLink}", resetLink))
        {
        }
    }
}
