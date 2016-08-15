using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Softcraftng.Medusa.MedusaCore.Medusa;
using Microsoft.Extensions.Logging;
using Softcraftng.Medusa.MedusaCore.Models.MedusaViewModels;
using Softcraftng.Medusa.MedusaCore.Medusa.TDomain;
using AutoMapper;

namespace Softcraftng.Medusa.MedusaCore.Controllers
{
    public class MedusaController : Controller
    {

        private IMedusa _medusa;
        private ILogger _logger;
        private IMapper _mapper;

        public MedusaController(IMedusa medusa, ILoggerFactory loggerFactory)
            : base()
        {
            _medusa = medusa;
            _logger = loggerFactory.CreateLogger<MedusaController>();
            _mapper = MappingConfig.mapperConfig.CreateMapper();
        }

        public IActionResult Search()
        {
            var result = new List<PersonViewModel>();

            return View(result);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Search(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                return Search();

            ViewBag.Search = searchString;
            var result = _medusa.Search(searchString);

            var list = _mapper.Map<IEnumerable<Person>, IEnumerable<PersonViewModel>>(result);
            return View(list);
        }

        public IActionResult AdvancedSearch()
        {

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AdvancedSearch(int id)
        {

            return View();
        }

        public IActionResult ViewProfile(string id)
        {

            var profile = _medusa.GetProfile(id);

            var viewProfile = _mapper.Map<Person, PersonViewModel>(profile);
            return View(viewProfile);
        }
    }
}
