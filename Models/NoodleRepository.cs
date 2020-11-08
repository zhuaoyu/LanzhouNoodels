using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lanzhoubeefNoodefs.Models
{

    //真正的面条仓库，连接数据库用
    public class NoodleRepository : INoodleRepository  //第一步：继承接口，实现接口里的方法
    {
        //第二步，使用数据库连接对象连接数据库
        private readonly AppDbContext context1;//2.1创建数据库连接器对象
        //2.2 在构造函数中使用传参的方式实现连接器
        public NoodleRepository(AppDbContext context)
        {
            context1 = context;//这个时候数据库与面条仓库的连接完成了，接着去实现下面方法
        }
        //第三步，实现接口的方法
        public IEnumerable<Noodle> GetAllNoodles()
        {
            return context1.Noodles;//返回所有面条
        }

        public Noodle GetNoodleById(int id)
        {
            return context1.Noodles.FirstOrDefault(n => n.ID == id);//FirstOrDefault返回序列中的第一个元素；如果不存在，返回默认值。
        }
        //第四步，注入依赖，在startup.cs文件
    }
}
//第五步，创建数据迁移代码。在顶部，打开视图，其他窗口，打开程序包管理控制器
//点击资源管理器里的项目名称，右键，生成
//回到程序包管理控制台
//输入 add-migration 自定义个名字  然后回车 如果出现问题 百度
//成功之后多了Migrtions的文件夹

//第六步，通过执行数据迁移代码来创建和执行数据库
//在程序包管理控制台输入：update-database
//当看到Done的时候，数据库就更新完毕了

//查看数据库;打开视图-SQLserver对象资源管理器