using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreTest.Controllers
{

    /// <summary>
    /// 类名称：EFController
    /// 命名空间：CoreTest.Controllers
    /// 类功能：
    /// </summary>
    /// 创建者：libb
    /// 创建日期：2019/5/9 14:21
    /// 修改者：
    /// 修改时间：
    /// -----------------------------------------------------------
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class EFController : Controller
    {
        private MyDbContext _myDbContext;

        public EFController(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public IActionResult Index()
        {
            #region 添加数据

            #region 添加单条

            //_myDbContext.Persons.Add(new Person()
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "bobo"
            //});
            //_myDbContext.Persons.Add(new Person()
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "bobo1"
            //});

            #endregion

            #region 添加多条记录

            //_myDbContext.Persons.AddRange(new List<Person>
            //{
            //     new Person
            //     {
            //         Id = Guid.NewGuid(),
            //        Name = "bobo2"
            //     },
            //     new Person
            //     {
            //         Id = Guid.NewGuid(),
            //        Name = "bobo3"
            //     }
            //});

            #endregion

            #endregion

            #region 删除数据

            //_myDbContext.Persons.RemoveRange(_myDbContext.Persons.Where(m => m.Name == "bobo").ToList());
            //_myDbContext.Persons.Remove(_myDbContext.Persons.Find(new object[] { Guid.Parse("77E77E7B-6FDD-440A-8310-45DBE644D1A4") }));

            #endregion

            #region 修改数据

            var getPerson = _myDbContext.Persons.Where(m => m.Name == "bobo1").FirstOrDefault();
            if (getPerson != null) {
                getPerson.Name = "bobo1_1";
            }

            #endregion

            //SaveChanges方法提交添加的数据到数据库，返回的是手影响的行数，即数据库插入几条数据
            _myDbContext.SaveChanges();

            var lists = _myDbContext.Persons.ToList();
            return Content("a");
        }
    }
}