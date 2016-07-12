using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softcraftng.Medusa.Messaging.Interface
{
    interface IEmailMessage
    {

        Task<MessageStatus> SendMessageAsync(string[] recipientTo, string[] recipientCC, string[] recipientBCC, string subject, string message, bool priority);

        Task<MessageStatus> SendTemplateEmailAsync(string template, string[] recipientTo, string[] recipientCC, string[] recipientBCC, string subject, string message, bool priority);
    }
}
