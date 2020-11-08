using System;
using lanzhoubeefNoodefs.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(lanzhoubeefNoodefs.Areas.Identity.IdentityHostingStartup))]
namespace lanzhoubeefNoodefs.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDefaultIdentity<IdentityUser>()
               .AddEntityFrameworkStores<AppDbContext>();//添加配置文件，使用默认配置完成对身份系统对的支持

            });
        }
    }
}