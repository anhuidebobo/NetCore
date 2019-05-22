using Autofac;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //IUserServer user = new UserServer();
            //user.Show();
            ContainerBuilder builder = new ContainerBuilder();

            //builder.RegisterType<UserServer>().As<IUserServer>();
            //builder.RegisterType<UserServer>().AsImplementedInterfaces();

            Assembly assembly = Assembly.Load("Service");
            //builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().PropertiesAutowired();

            IContainer container = builder.Build();
            IUserServer userServer = container.Resolve<IUserServer>();
            userServer.Show();

            Console.ReadLine();
        }
    }
}
