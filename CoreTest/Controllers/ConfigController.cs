using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoreTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CoreTest.Controllers
{
    public class ConfigController : Controller
    {
        private Person person;
        private UserName userName;
        #region 读取配置文件方式二-------3
        public ConfigController(IOptions<Person> options, IOptions<UserName> optionsUserName)
        {
            this.person = options.Value;
            this.userName = optionsUserName.Value;
        }
        #endregion
        public IActionResult Index()
        {
            #region 读取配置文件方式一
            //ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            //configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json");
            //var configuration = configurationBuilder.Build();
            //string defaultConnection = configuration.GetConnectionString("DefaultConnection");
            //string name = configuration.GetValue<string>("name");
            //string name = configuration["name"];
            //var person = configuration["person:age"];
            //var username = configuration["username:0:id"];
            //return Content(defaultConnection + "-" + username);
            #endregion

            return Content(this.person.Name+"-"+this.userName.Name);
        }
    }
}