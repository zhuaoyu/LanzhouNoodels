using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lanzhoubeefNoodefs.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace lanzhoubeefNoodefs
{
    public class Program
    {
        public static void Main(string[] args)//在程序启动前完成数据添加的工作
        {
            // CreateHostBuilder(args).Build().Run();//注释掉之前的代码
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;//访问系统依赖容器获取数据库连接对象DbContext
                try
                {
                    var context = services.GetRequiredService<AppDbContext>();
                    DbInitializer.Seed(context);//托管服务器运行前添加我们的测试数据
                }
                catch (Exception)
                {
                    //故意留空，以后可以添加日志
                }
            }

            host.Run();//不管是否添加，让系统运行起来
        }

            public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
