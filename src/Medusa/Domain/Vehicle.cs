using Softcraftng.Medusa.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softcraftng.Medusa.Domain
{
    public class Vehicle
    {
        public Guid Id { get; set; }

        public string VIN { get; set; }

        public string Color { get; set; }

        public string Chasis { get; set; }

        public string RegistrationNumber { get; set; }

        public string EngineNumber { get; set; }

        public IEnumerable<IEntity> Owners { get; set; }
    }
}
