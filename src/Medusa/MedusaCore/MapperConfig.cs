using AutoMapper;
using Softcraftng.Medusa.MedusaCore.Medusa.TDomain;
using Softcraftng.Medusa.MedusaCore.Models.MedusaViewModels;
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
                cfg.CreateMap<Person, PersonViewModel>();
                cfg.CreateMap<PersonViewModel, Person>();

            });

            mapperConfig = config;
        }

    }
}
