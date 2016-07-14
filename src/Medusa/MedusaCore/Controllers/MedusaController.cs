using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Softcraftng.Medusa.MedusaCore.Controllers
{
    public class MedusaController : Controller
    {

        public IActionResult Search()
        {

            return View();
        }
    }
}
