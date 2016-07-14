using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Softcraftng.Medusa.MedusaCore.Localization
{
    public class JsonStringLocalizer : IStringLocalizer
    {

        private readonly IConfiguration _configuration;

        public JsonStringLocalizer(string basePath, string resourceTypeName)
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(basePath);

            configurationBuilder.AddJsonFile($"{resourceTypeName}.json");

            _configuration = configurationBuilder.Build();
        }

        public LocalizedString this[string name]
        {
            get
            {
                return this[name, new object[0]];
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var value = _configuration[name];

                return new LocalizedString(name, string.Format(value ?? name, arguments), value == null);
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeAncestorCultures)
        {
            throw new NotImplementedException();
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
