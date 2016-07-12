using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softcraftng.Medusa.Messaging.Interface
{
    public interface IProviderMessage
    {
        Task<MessageStatus> SendMessageAsyc(string[] recipient, string message);
    }
}
