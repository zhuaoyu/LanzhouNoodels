using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lanzhoubeefNoodefs.Models;//第一步，引用Models

namespace lanzhoubeefNoodefs.ViewModels
{
    public class HomeViewModel
    {
        public IList<Noodle> Noodles { get; set; }//第二步，获取数据，列表用Ilist<>
        public IList<Feedback> Feedbacks { get; set; }
    }
}

//使用ViewModels进行数据的展示
//第一步using解决方案名.Models
//第二步，获取数据
//第三步，转到对应的控制器，这里是Home