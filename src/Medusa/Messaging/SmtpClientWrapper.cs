using Softcraftng.Medusa.Messaging.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Softcraftng.Medusa.Messaging
{
    public class SmtpClientWrapper : ISmtpClient
    {
        public event AsyncCompletedEventHandler SendCompleted;

        public SmtpClient smtpClient { get; set; }

        public SmtpClientWrapper(string host, int port)
        {
            smtpClient = new SmtpClient(host, port);
            smtpClient.SendCompleted += SmtpClient_SendCompleted;
        }

        private void SmtpClient_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            OnSendCompleted(sender, e);
        }

        public async Task SendMailAsync(MailMessage mailMessage)
        {
            await smtpClient.SendMailAsync(mailMessage);
        }

        public void OnSendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            SendCompleted?.Invoke(sender, e);
        }
    }
}
