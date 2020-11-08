using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lanzhoubeefNoodefs.Models
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AppDbContext context1; 
       
        public FeedbackRepository(AppDbContext context)
        {
            context1 = context;  
        }
        public void addFeedback(Feedback feedback)
        {
            context1.Feedbacks.Add(feedback);
            context1.SaveChanges();//添加新评价并保存到数据库
        }

        public IEnumerable<Feedback> GetALLFeedback()
        {
            return context1.Feedbacks;

        }
    }
}
