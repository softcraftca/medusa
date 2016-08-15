using Softcraftng.Medusa.MedusaCore.Medusa.TDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softcraftng.Medusa.MedusaCore.Medusa
{
    public class Medusa : IMedusa
    {
        public Person GetProfile(string id)
        {

            return new Person() { Id = Guid.NewGuid(), FirstName = "Seun", LastName = "Arije", NickName = "ariko", Email = "seun.arije@yahoo.com", Sex = "M" };
        }

        public IEnumerable<Person> Search(string searchString)
        {
            var list = new List<Person>
            {
                new Person() { Id = Guid.NewGuid(), FirstName = "Seun", LastName = "Arije", NickName = "ariko", Email = "seun.arije@yahoo.com", Sex = "M" },
                new Person() { Id = Guid.NewGuid(), FirstName = "Dayo", LastName = "Ogutuga", NickName = "tuga", Email = "dayoogu@gmail.com", Sex = "F" },
                new Person() { Id = Guid.NewGuid(),  FirstName = "Charles", LastName = "Okoro", NickName = "chokco", Email = "choko.milo@gmail.ca", Sex = "M" }
            };

            list.AddRange(list);
            list.AddRange(list);
            list.AddRange(list);
            list.AddRange(list);

            return list;
        }
    }
}
