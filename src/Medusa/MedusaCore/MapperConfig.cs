using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softcraftng.Medusa.MedusaCore
{
    public static class MappingConfig
    {
        public static MapperConfiguration mapperConfig;

        public static void RegisterMaps()
        {
            var config = new MapperConfiguration(cfg =>
            {


            });

            mapperConfig = config;
        }

    }
}
