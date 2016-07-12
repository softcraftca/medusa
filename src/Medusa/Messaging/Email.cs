using Microsoft.Extensions.Logging;
using Softcraftng.Medusa.Messaging.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Softcraftng.Medusa.Messaging
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Email : IEmailMessage
    {
        private ISmtpClient _smtpClient;
        private ILogger _logger;

        public Email(ISmtpClient smtpClient, ILoggerFactory loggerFactory)
        {
            if (smtpClient == null)
                new ArgumentException("Null cliet argument passed for email system");

            _smtpClient = smtpClient;
            _logger = loggerFactory.CreateLogger<Email>();
        }

        public async Task<MessageStatus> SendMessageAsync(string[] recipientTo, string[] recipientCC, string[] recipientBCC, string subject, string message, bool priority)
        {
            
            _smtpClient.SendCompleted += SmtpClient_SendCompleted;

            // compose message
            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("dapo.onawole@gmail.com");

            // add recipients
            foreach (var recipient in recipientTo)
                mailMessage.To.Add(recipient);

            foreach (var recipient in recipientCC)
                mailMessage.CC.Add(recipient);

            foreach (var recipient in recipientBCC)
                mailMessage.Bcc.Add(recipient);

            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            
            mailMessage.Subject = subject;
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = true;
            if (priority) mailMessage.Priority = MailPriority.High;

            try
            {
                _logger.LogInformation("Sending email", mailMessage);
                await _smtpClient.SendMailAsync(mailMessage);
                return MessageStatus.Success;
            }
            catch (Exception ex)
            {
                // log exception
                _logger.LogError(ex.Message, ex);
                return MessageStatus.Error;// await Task.FromResult<MessageStatus>(MessageStatus.Error);
            }

        }

        public async Task<MessageStatus> SendTemplateEmailAsync(string template, string[] recipientTo, string[] recipientCC, string[] recipientBCC, string subject, string message, bool priority)
        {
            // load template

            return await SendMessageAsync(recipientTo, recipientCC, recipientBCC, subject, message, priority);
        }

        private void SmtpClient_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {

            // log
            _logger.LogInformation("Email sent", sender, e);

        }
    }
}
