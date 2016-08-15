using Softcraftng.Medusa.MedusaCore.Medusa.TDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softcraftng.Medusa.MedusaCore.Medusa
{
    public interface IMedusa
    {
        IEnumerable<Person> Search(string searchString);

        Person GetProfile(string id);
    }
}
