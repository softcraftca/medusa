using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softcraftng.Medusa.Messaging
{
    public class PhoneCall
    {
        private ILogger _logger;

        public PhoneCall(string provider, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<PhoneCall>();
        }

        public async Task PlaceCall(string phoneNumber)
        {

            _logger.LogInformation("Placing voice call", phoneNumber);

            await Task.FromResult(0);
        }
    }
}
