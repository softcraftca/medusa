using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softcraftng.Medusa.MedusaCore.Models.MedusaViewModels
{
    public class SearchViewModel
    {
        public string SearchString { get; set; }

        public IEnumerable<string> Result { get; set; }
    }
}
