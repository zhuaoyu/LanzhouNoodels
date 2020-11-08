using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lanzhoubeefNoodefs.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;//1.5先using，再引用下面的
using Microsoft.EntityFrameworkCore.SqlServer;//1.5 因为使用数据库，还有引用这个。如果没有，就邮件解决方案，管理NuGet,搜索sqlserver,然后安装，就可以引用了
using Microsoft.Extensions.Configuration;//1.9调用连接字符串前先引用
using Microsoft.AspNetCore.Identity;//2.4添加引用


namespace lanzhoubeefNoodefs
{
    public class Startup
    {
        public IConfiguration Configuration { get; }//1.10引用这个链接数据库的字符串，只读就够了
        public Startup(IConfiguration configuration)//1.11通过构造函数使用数据库连接字符串
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)//注入服务组建的依赖（自定义的和系统自带的）
        {
            //1.6注入数据库连接字符串.先完成1.7到1.11，再调用数据库连接字符串UseSqlServer(上面创建的函数名.get方法名（“appsetting里的字符串名”）)
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //1.7点击项目名，添加新建项，搜索app，然后添加应用文件（appsettings.json）转这个文件
            services.AddMvc(options => { options.EnableEndpointRouting = false; })
             .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
            services.AddControllers();//注入MVC服务器组建依赖
                                      // services.AddMvc();
            services.AddTransient<INoodleRepository, NoodleRepository>();//注入依赖  面条模型  MOCK是假仓库 后期换成真仓库
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();//评价模型       
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)//设置系统http请求通道
        {//中间件middelware，用来接收上一个中间件的处理结果，然后加上自己的结果传递给下一个中间件
            //一般mvc为最后一个中间件（有些可以做短路处理，直接向前端输出）
            //所有中间件公共一个通道，所以顺序很重要
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();//在运行时，引用wwwroot文件
            app.UseAuthentication();//2.5绑定控件，引用Identity，右键项目名称，生成。然后在程序包控制台，下面2.6继续
            app.UseRouting();
            //这个路由规则等同于app.UseMvcWithDefaultRoute();，只是内容可以自定义了。
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
            });
            // app.UseMvcWithDefaultRoute();//添加默认规则，从home到index（上面添加mvc的代码需求修改）


            // app.Map("/test", build =>//第一个参数为url，第二个参数为处理对象，run表示短路处理。
            //  {
            //     build.Run(async context => {
            //         await context.Response.WriteAsync("hello form test");//等待后异步处理字符串
            //      });
            // });

            app.UseEndpoints(endpoints =>
              {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
               });//结束标志1
              });//结束标志2

     

        }
    }
}

//第四步，在ConfigureServices里注入依赖（有三种方法，下面是介绍），services.AddTransient<接口类文件名（第二步做的）, 实现接口类文件（第三步做的,需要using引入Model）>();
//AddTransient方法优点：每次发起请求创建一个全新的面条仓库，结束后自动注销掉。优点：不同的请求间完全独立，互不影响
//AddSingleton:系统启动的时候创建一个，有且仅有一个，以后每次处理请求都是用这个。（所有请求公用一个仓库，容易污染数据库）
//AddScoped上面两种方法的集合，更麻烦一点
//第五步。显示数据，绑定数据模型。打开控制器Home

//数据库注入容器，1.5开始

//IdentityDbContext的引用，从2.4添加引用开始
//2.6 在程序包控制台输入：add-migration 自定义名称（IdentityInit） 完成之后
//2.7 输入update-database 看到done。数据库更新完成  表示asp.net身份认证功能正式启用