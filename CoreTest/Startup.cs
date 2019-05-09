using CoreTest.Models;
using CoreTest.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace CoreTest
{
    public class Startup
    {
        private IConfiguration configuration;

        #region 读取配置文件方式二-------1
        //public Startup()
        //{

        //    ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
        //    configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json");
        //    configuration = configurationBuilder.Build();
        //}
        #endregion
        #region 读取配置文件方式二-------1   可取代上面的方式进行简化处理
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #endregion
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                {
                    o.LoginPath = new PathString("/Home/Login");
                });

            #region 读取配置文件方式二-------2
            services.Configure<Person>(configuration.GetSection("person"));
            services.Configure<UserName>(configuration.GetSection("username"));
            #endregion

            #region Di 依赖注入

            //每个调用都创建一个
            services.AddTransient<IService, MyService>();
            ////一个请求域一个
            //services.AddScoped<IService, MyService>();
            ////单例
            //services.AddSingleton<IService, MyService>();

            #endregion


            #region 数据库连接  ORM
            services.AddDbContextPool<MyDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvcWithDefaultRoute();

            //app.UseStaticFiles(new StaticFileOptions() {
            //     FileProvider=new PhysicalFileProvider(Directory.GetCurrentDirectory())
            // });
            app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(
            //        Path.Combine(Directory.GetCurrentDirectory(),"Images")),
            //    RequestPath =new PathString("/Images")

            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});


        }
    }
}