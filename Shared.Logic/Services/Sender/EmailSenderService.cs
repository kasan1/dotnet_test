using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using Agro.Shared.Data;
using Agro.Shared.Logic.Models.Email;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Agro.Shared.Logic.Services.Sender
{
    public class EmailSenderService : ISenderService
    {
        private readonly string _smtpClientName, _smtpClientPort, 
                            _login, _password, _defaultRecipient;

        private readonly IWebHostEnvironment _env;

        public EmailSenderService(IOptions<AppSettings> _options, IWebHostEnvironment env)
        {
            _smtpClientName = _options.Value.Emails.SmtpClientName;
            _smtpClientPort = _options.Value.Emails.SmtpClientPort;
            _login = _options.Value.Emails.Login;
            _password = _options.Value.Emails.Password;
            _defaultRecipient = _options.Value.Emails.DefaultRecipient;
            _env = env;
        }

        public void Send(EmailMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("Параметр сообщения не должен быть null", nameof(message));
            }

            // Override recipient of email for non production environments
            if (!_env.IsProduction())
            {
                message.Subject = $"{_env.EnvironmentName.ToUpper()}: {message.Subject}";
                message.To = new List<string>() { _defaultRecipient };
            }

            using var emailMessage = new MailMessage()
            {
                From = new MailAddress(_login, "BPM.KAF"),
                Subject = message.Subject,
                Body = message.Content,
                IsBodyHtml = true
            };

            foreach (var recipient in message.To)
            {
                emailMessage.To.Add(new MailAddress(recipient));
            }

            foreach (var recipient in message.CC)
            {
                emailMessage.CC.Add(new MailAddress(recipient));
            }

            using (var client = new SmtpClient(_smtpClientName))
            {
                client.Port = Convert.ToInt32(_smtpClientPort);
                client.Credentials = new NetworkCredential(_login, _password);
                client.EnableSsl = true;
                client.Send(emailMessage);
            }
        }
    }
}
