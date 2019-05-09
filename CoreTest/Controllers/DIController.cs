using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreTest.Controllers
{
    public class DIController : Controller
    {
        private IService _service;
        private MyDbContext _myDbContext;
        public DIController(IService service,MyDbContext myDbContext)
        {
            this._service = service;
            this._myDbContext = myDbContext;
        }
        public IActionResult Index()
        {
            string name = this._service.GetName();
            return Content(name);
        }
    }
}