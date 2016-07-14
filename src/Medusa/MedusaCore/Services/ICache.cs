﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softcraftng.Medusa.MedusaCore.Services
{
    interface ICache
    {

        void Set<T>(string key, T value);


        T Get<T>(string key);
    }
}
