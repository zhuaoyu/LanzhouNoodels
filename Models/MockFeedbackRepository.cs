using lanzhoubeefNoodefs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lanzhoubeefNoodefs.Models
{
    public class MockFeedbackRepository : IFeedbackRepository
    {
        private List<Feedback> feedbacks;
        public MockFeedbackRepository()
        {
            if (feedbacks == null)
            {
                initializeFeedback();
            }
        }
        private void initializeFeedback()
        {
            feedbacks = new List<Feedback>
            {
                new Feedback{id=1,name="白菜1",emall="2399436117@qq.com1",createdateutc=Convert.ToDateTime("8/19/2019 1:26:57 AM"),message="真好吃"},//转换datetime要提前声明，即Convert.ToDateTime
                 new Feedback{id=2,name="白菜2",emall="2399436117@qq.com2",createdateutc=Convert.ToDateTime("8/19/2019 1:26:57 AM"),message="真好吃"},
                  new Feedback{id=3,name="白菜3",emall="2399436117@qq.com3",createdateutc=Convert.ToDateTime("8/19/2019 1:26:57 AM"),message="真好吃"}
            };
        }

       
        public IEnumerable<Feedback> GetALLFeedback()
        {
            return feedbacks;
        }
  

        public void addFeedback(Feedback feedback)//传入数据1.2：实现接口,加下来应用到控制器Feedback
        {
            feedbacks.Add(feedback);
        }
    }
}
