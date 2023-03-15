using Agro.Shared.Logic.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agro.Shared.Logic.Services.Sender.Operations
{
    public abstract class BaseEmailOperation : IEmailOperation
    {
        private readonly string _subject;
        private readonly string _messageTemplate;

        public BaseEmailOperation(string subject, string messageTemplate)
        {
            _subject = subject;
            _messageTemplate = messageTemplate;
        }

        public EmailMessage GetMessage(List<string> recipients, List<string> ccRecipients = null)
        {
            var emailMessage = new EmailMessage();
            if (recipients == null || !recipients.Any())
            {
                throw new ArgumentException("Список получателей писем не должен быть пустым", nameof(recipients));
            }

            emailMessage.To = recipients;
            emailMessage.Subject = _subject;

            // TODO: Add header and footer
            emailMessage.Content = _messageTemplate; 

            if (ccRecipients != null)
            {
                emailMessage.CC = ccRecipients;
            }

            return emailMessage;
        }
    }
}
