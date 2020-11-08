using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lanzhoubeefNoodefs.Models
{//用来向数据库添加数据
    public static class DbInitializer//1.0改为静态  调用函数成为添加数据
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Noodles.Any())
            {
                return;
            }
        context.AddRange
            (
                new Noodle { name = "毛细", price = 12, shortDescription = "如发丝般细", longDescription = "真的好细好细好细啊", urlimage = "/images/毛细.png" },
                new Noodle { name = "细", price = 10, shortDescription = "普通细", longDescription = "还是挺细的", urlimage = "/images/细.png" },
                new Noodle { name = "三细", price = 11, shortDescription = "有点粗了", longDescription = "比细的粗点，比二细细点", urlimage = "/images/三细.png" },
                new Noodle { name = "二细", price = 10, shortDescription = "粗了", longDescription = "粗的才有嚼劲", urlimage = "/images/二细.png" },
                new Noodle { name = "二柱子", price = 11, shortDescription = "太粗了", longDescription = "粗得快咬不动了", urlimage = "/images/二柱子.png" },
                new Noodle { name = "韭叶子", price = 12, shortDescription = "扁的", longDescription = "韭猜叶一样宽", urlimage = "/images/韭叶子.png" },
                new Noodle { name = "薄宽", price = 11, shortDescription = "开始宽了", longDescription = "比韭叶宽一点，比大宽窄一点", urlimage = "/images/薄宽.png" },
                new Noodle { name = "大宽", price = 10, shortDescription = "裤带面", longDescription = "比嘴还宽了", urlimage = "/images/大宽.png" },
                new Noodle { name = "荞麦棱子", price = 15, shortDescription = "立方体的", longDescription = "好像知道师傅怎么拉出来的", urlimage = "/images/荞麦棱子.png" },
                new Noodle { name = "一窝丝", price = 15, shortDescription = "这是啥", longDescription = "我也没吃过", urlimage = "/images/一窝丝.png" }

            );

            context.SaveChanges();//保存到数据库

            //下一步，调动且执行这段代码添加到数据库，进去Program文件
        }
    }
}
