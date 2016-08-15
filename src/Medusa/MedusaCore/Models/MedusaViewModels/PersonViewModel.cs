using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Softcraftng.Medusa.MedusaCore.Models.MedusaViewModels
{
    public class PersonViewModel
    {

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public string Sex { get; set; }

        public string Email { get; set; }

        [Display(Name ="Name")]
        public string FullName
        {
            get { return $"{LastName}, {FirstName} {MiddleName}"; }
        }

    }
}
