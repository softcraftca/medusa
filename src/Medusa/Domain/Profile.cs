using Softcraftng.Medusa.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softcraftng.Medusa.Domain
{
    public class Profile
    {
        public string SourceId { get; set; }

        public string Source { get; set; }

        public Guid Id { get; set; }

        public byte[] Photos { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Sex { get; set; }

        public string Location { get; set; }

        public Address Address { get; set; }

        public string[] PhoneNumbers { get; set; }

        public DateTime DateofBirth { get; set; }

        public string[] Languages { get; set; }

        public string Religion { get; set; }

        public string Interest { get; set; }

        public string AboutMe { get; set; }

        public string NickNames { get; set; }

        public string BirthName { get; set; }

        public string[] LifeEvents { get; set; }

        public MaritalStatus MaritalStatus { get; set; }


        public string[] RecentPosts { get; set; }
    }
}
