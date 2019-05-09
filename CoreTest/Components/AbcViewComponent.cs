using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telsafe.Platform.BasicModules.HomeModules.Controllers;

namespace CoreTest.Components
{
    public class AbcViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View("Default",10);
        }
    }
}
