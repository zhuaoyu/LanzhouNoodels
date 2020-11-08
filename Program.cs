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
        public static void Main(string[] args)//�ڳ�������ǰ���������ӵĹ���
        {
            // CreateHostBuilder(args).Build().Run();//ע�͵�֮ǰ�Ĵ���
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;//����ϵͳ����������ȡ���ݿ����Ӷ���DbContext
                try
                {
                    var context = services.GetRequiredService<AppDbContext>();
                    DbInitializer.Seed(context);//�йܷ���������ǰ������ǵĲ�������
                }
                catch (Exception)
                {
                    //�������գ��Ժ���������־
                }
            }

            host.Run();//�����Ƿ���ӣ���ϵͳ��������
        }

            public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
