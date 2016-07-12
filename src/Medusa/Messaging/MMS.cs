using Microsoft.Extensions.Logging;
using Softcraftng.Medusa.Messaging.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softcraftng.Medusa.Messaging
{
    public class MMS : IProviderMessage
    {
        private ILogger _logger;

        public MMS(string provider, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<MMS>();
        }

        public async Task<MessageStatus> SendMessageAsyc(string[] recipient, string message)
        {

            _logger.LogInformation("Sending MMS", message);

            return await Task.FromResult<MessageStatus>(MessageStatus.Success);
        }
    }
}
