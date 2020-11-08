using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lanzhoubeefNoodefs.Models
{
    public class MockNoodleRepository : INoodleRepository//继承刚才创建的接口类，并右键实现接口方法
    {
        private List<Noodle> noodles;//创建一个私有列表，相当于数据库

        public MockNoodleRepository()//一个构建函数（名称固定），用来调用方法写入数据
        {
            if (noodles == null)
            {
                initalizaNoodle();
            }

        }
        private void initalizaNoodle() //一个方法，用来写入数据
        {
            noodles = new List<Noodle>
            {
                new Noodle{ID=1,name="面条",price=121,shortDescription="真好吃1",longDescription="是真的好吃1",urlimage="~/images/1.png"},
                new Noodle{ID=2,name="面条2",price=122,shortDescription="真好吃2",longDescription="是真的好吃2",urlimage="~/images/2.png"},
                new Noodle{ID=3,name="面条3",price=123,shortDescription="真好吃3",longDescription="是真的好吃3",urlimage="~/images/3.png"}
            };
        }
        public IEnumerable<Noodle> GetAllNoodles()
        {
            return noodles;//返回面条列表
        }

        public Noodle GetNoodleById(int id)
        {
            return noodles.FirstOrDefault(n => n.ID == id);//FirstOrDefault:返回序列中的第一个元素,如果查询的数据不存在， 则返回 null
        }
    }
}
//第三步，实现接口
//继承刚才创建的接口类，并实现接口方法（第二步接口类文件里自己创建的方法）
//创建假数据库：创建一个私有列表
//一个方法，写入数据
//一个构建函数，调用方法，写入数据
//给接口创建的方法去实现。
//第四步，注入系统的依赖注册容器中，在startup.cs中进行
