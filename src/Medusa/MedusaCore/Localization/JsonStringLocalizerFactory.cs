using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Softcraftng.Medusa.MedusaCore.Localization
{
    public class JsonStringLocalizerFactory : IStringLocalizerFactory
    {

        private readonly ApplicationEnvironment _appEnv;
        private readonly IOptions<JsonLocalizationOptions> _jsonOptions;

        public JsonStringLocalizerFactory(ApplicationEnvironment appEnv,
                                                       IOptions<JsonLocalizationOptions> jsonConfigurationLocalizationOptions)
        {
            _appEnv = appEnv;
            _jsonOptions = jsonConfigurationLocalizationOptions;
        }

        public IStringLocalizer Create(Type resourceSource)
        {
            var resourceTypeName = resourceSource.Name;

            return null; // new JsonStringLocalizerFactory(Path.Combine(_appEnv.ApplicationBasePath, _jsonOptions.Value.BasePath),
                         //                               resourceTypeName);
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            throw new NotImplementedException();
        }
    }

    public class JsonLocalizationOptions
    {
        public string BasePath { get; set; }
    }
}
