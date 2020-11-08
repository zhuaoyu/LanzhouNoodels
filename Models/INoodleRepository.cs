using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lanzhoubeefNoodefs.Models
{
   public interface INoodleRepository
    {
        IEnumerable<Noodle> GetAllNoodles();//返回一个类型Noodle的列表（IEnumerable表示返回列表+<表名称>+自定义名称+（）；）
        Noodle GetNoodleById(int id);//根据id返回一个类型为Noodle的值
    }
}
//第二步创建连接接口
//增加public
//根据表名称和类型创建接口API（是返回所有列表还是根据查询只返回一个值）
//下一步是实现接口，添加类文件。