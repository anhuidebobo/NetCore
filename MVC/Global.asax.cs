using Autofac;
using Autofac.Integration.Mvc;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var builder = new ContainerBuilder();
            //将当前程序集中的Controller都注册
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();


            Assembly assembly = Assembly.Load("Service");
            builder.RegisterAssemblyTypes(assembly).Where(t => !t.IsAbstract && t.Name.EndsWith("Server"))
                .AsImplementedInterfaces().PropertiesAutowired();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


            IScheduler scheduler = new StdSchedulerFactory().GetScheduler();
            JobDetailImpl jobDetailImpl = new JobDetailImpl("jdTest", typeof(TestJob));
            //IMutableTrigger mutableTrigger = CronScheduleBuilder.DailyAtHourAndMinute(0, 1).Build();

            CalendarIntervalScheduleBuilder scBuilder = CalendarIntervalScheduleBuilder.Create();
            scBuilder.WithInterval(10, IntervalUnit.Second);
            IMutableTrigger mutableTrigger = scBuilder.Build();

            mutableTrigger.Key = new TriggerKey("triggerTest");
            scheduler.ScheduleJob(jobDetailImpl, mutableTrigger);
            scheduler.Start();
        }
    }
}
