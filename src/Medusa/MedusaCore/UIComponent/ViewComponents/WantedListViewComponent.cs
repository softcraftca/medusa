using Microsoft.AspNetCore.Mvc;
using Softcraftng.Medusa.MedusaCore.Medusa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softcraftng.Medusa.MedusaCore.UIComponent.ViewComponents
{
    [ViewComponent(Name = "WantedList")]
    public class WantedListViewComponent : ViewComponent
    {
        private readonly IMedusa _medusa;

        public WantedListViewComponent(IMedusa medusa)
        {
            _medusa = medusa;
        }

        public IViewComponentResult Invoke(int count)
        {
            var list = new List<Models.MedusaViewModels.PersonViewModel>()
            {
                new Models.MedusaViewModels.PersonViewModel() { FirstName = "Dele" },
                new Models.MedusaViewModels.PersonViewModel() { FirstName = "Segun" }
            };

            return View(list);
        }
    }
}
