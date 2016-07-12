using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Softcraftng.Medusa.Messaging.Interface
{
    public interface ISmtpClient
    {
        event AsyncCompletedEventHandler SendCompleted;

        Task SendMailAsync(MailMessage message);
    }
}
