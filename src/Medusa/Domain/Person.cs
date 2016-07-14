using Softcraftng.Medusa.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softcraftng.Medusa.Domain
{
    public class Person : IEntity
    {
        public Guid Id { get; set; }

        public byte[] Photos { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Sex { get; set; }

        public Address Address { get; set; }

        public string Interest { get; set; }

        public string EyeProfile { get; set; }

        public string Biometrics { get; set; }

        public string HairColor { get; set; }

        public string SkinColor { get; set; }

        public string EyeColor { get; set; }

        public string ShoeSize { get; set; }

        public float Height { get; set; } // in metres

        public float Weight { get; set; } // in kg

        public string DescriptiveFeatures { get; set; }


        public string Relationships { get; set; } //TODO: Refactor


    }
}
