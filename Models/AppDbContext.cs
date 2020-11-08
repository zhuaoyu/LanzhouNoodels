using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;//1.0添加引用，如果没有，右击解决方案-还原NuGet包管理-Microsoft.EntityFrameworkCore-安装
using Microsoft.AspNetCore.Identity;//2.1添加框架
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;//2.1添加框架的对象

namespace lanzhoubeefNoodefs.Models
{

    //这就是数据库连接器。用在真正的数据库仓库中
    //2.0引入Identity做验证，用户注册登录等功能。
    public class AppDbContext: IdentityDbContext<IdentityUser>//在数据库和代码之间的连接器，引导数据流动//1.1继承DbContext,这里DbContext来自刚才的using//2.2修改为继承为IdentityDbContext,IdentityUser的作用是用户列表映射，如果数据库不存在用户表自动添加表
    //2.3把IdentityDbContext嵌入到请求通道里去，转startup文件
    {//注入上下文对象的实例
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)//1.2根据需求写这个
        {

        }
        public DbSet<Noodle> Noodles { get; set; } //1.3把需要用到的数据库类引用到这里
        public DbSet<Feedback> Feedbacks { get; set; }//1.4注入容器，转Startup.cs  
    }
}
