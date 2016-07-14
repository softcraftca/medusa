using Softcraftng.Medusa.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softcraftng.Medusa.Domain
{
    public class Organization : IEntity
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string IncorporationNumber { get; set; }

        public Address Address { get; set; }

        public Person ContactPerson { get; set; }

        public IEnumerable<Person> Directors { get; set; }
    }
}
