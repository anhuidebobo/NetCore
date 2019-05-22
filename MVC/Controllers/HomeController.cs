using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private IUserServer _userService;
        public HomeController(IUserServer userService)
        {
            this._userService = userService;
        }

        // GET: Home
        public ActionResult Index()
        {
            _userService.Show();
            //在没有Autofac依赖注入的类中可以使用
            IUserServer user = DependencyResolver.Current.GetService<IUserServer>();
            return View();
        }
    }
}