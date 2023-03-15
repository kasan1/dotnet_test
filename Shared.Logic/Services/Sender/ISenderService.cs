using Agro.Shared.Logic.Models.Email;

namespace Agro.Shared.Logic.Services.Sender
{
    public interface ISenderService
    {
        void Send(EmailMessage emailMessage);
    }
}
