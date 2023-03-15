using Agro.Shared.Logic.Models.Email;
using System.Collections.Generic;

namespace Agro.Shared.Logic.Services.Sender.Operations
{
    public interface IEmailOperation
    {
        EmailMessage GetMessage(List<string> recipients, List<string> ccRecipients = null);
    }
}
