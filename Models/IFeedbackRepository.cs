using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lanzhoubeefNoodefs.Models
{
   public interface IFeedbackRepository//创建接口实现调用所有评论
    {
        IEnumerable<Feedback> GetALLFeedback();     //查询所有品论
        void addFeedback(Feedback feedback);//传入数据：1.1 添加一个传入评论的接口，接下来实现接口（注意可以选中然后实现接口快速创建方法）

    }
}
