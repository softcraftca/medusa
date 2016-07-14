using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softcraftng.Medusa.Domain
{
    public class Relationship
    {
        public Person Person1 { get; set; }

        public Person Person2 { get; set; }

        public string RelationshipType { get; set; }
    }
}
