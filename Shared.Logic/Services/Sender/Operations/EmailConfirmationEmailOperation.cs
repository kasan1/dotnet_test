namespace Agro.Shared.Logic.Services.Sender.Operations
{
    public class EmailConfirmationEmailOperation : BaseEmailOperation
    {
        private static readonly string _template = @"
            <div>
                <header>
                    <h3>Вы зарегистрировались в системе ОКАПС.</h3>
                </header>
                <section>
                    <p>Для подтверждения электронной почты пожалуйста пройдите <a href='{resetLink}'>по ссылке</a>.</p>
                </section>
            </div>
        ";

        public EmailConfirmationEmailOperation(string resetLink) : base("Подтверждение электронной почты", _template.Replace("{resetLink}", resetLink))
        {
        }
    }
}
