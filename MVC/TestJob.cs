using Autofac;
using Autofac.Integration.Mvc;
using Quartz;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVC
{
    public class TestJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                IUserServer userServer = null;
                //IUserServer userServer = DependencyResolver.Current.GetService<IUserServer>();
                var containner = AutofacDependencyResolver.Current.ApplicationContainer;
                using (containner.BeginLifetimeScope())
                {
                    userServer = containner.Resolve<IUserServer>();
                }
                userServer.Show();
            }
            catch (Exception e)
            {
                //throw;
            }
        }
    }
}
