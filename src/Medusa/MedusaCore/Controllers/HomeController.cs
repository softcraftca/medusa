using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Softcraftng.Medusa.MedusaCore.Data;

namespace Softcraftng.Medusa.MedusaCore.Controllers
{
    public class HomeController : Controller
    {
        private ILogger _logger;
        private IRepository _repository;

        public HomeController(IRepository repository, ILoggerFactory loggerFactory)
            : base()
        {
            _repository = repository;
            _logger = loggerFactory.CreateLogger<HomeController>();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
