using CoreTest.Filters;
using CoreTest.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace CoreTest.Controllers
{
    public class HomeController : Controller
    {
        [ResourceFilter]
        [ActionFilter]
        [ExceptionFilter]
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public IActionResult Index()
        {
            //throw new Exception("发生错误");

            UserName model = new UserName { ID = 1, Name = "bobo" };
            return View(model);
        }

        public IActionResult Login()
        {
            return Content("Login");
        }

        public IActionResult DoLogin()
        {
            ClaimsIdentity identity = new ClaimsIdentity("Forms");
            string token = "123456";
            string name = "bobo";
            identity.AddClaim(new Claim(ClaimTypes.Sid, token));
            identity.AddClaim(new Claim(ClaimTypes.Name, name));

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

            return Content("登录成功");
        }

        [Authorize(AuthenticationSchemes =CookieAuthenticationDefaults.AuthenticationScheme)]
        public IActionResult Center()
        {
            string token = User.FindFirst(ClaimTypes.Sid).Value;
            //HttpContext.User.FindFirstValue(ClaimTypes.Sid);
            return Content("Center");
        }

    }
}