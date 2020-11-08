using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lanzhoubeefNoodefs.Models;
using Microsoft.AspNetCore.Mvc;

namespace lanzhoubeefNoodefs.controllers
{
    public class FeedbackController : Controller
    {
        private IFeedbackRepository feedbackRepository;//老规则，创建接口
        public FeedbackController(IFeedbackRepository feedback)//构造函数实现接口
        {
            feedbackRepository = feedback;
        }
        public IActionResult Index()//传入数据1.3：添加视图//这个界面负责填写信息并用post传值 注意view视图需要引用数据模型Feedback
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Feedback feedback)//创建模型类接收传过来的数据
        {
            if (ModelState.IsValid)//对传来的数据进行验证
            {
                feedbackRepository.addFeedback(feedback);//接收数据并填加到仓库
                return RedirectToAction("FeebackComplete");//转到其他action
            }
            return View();
        }
        public IActionResult FeebackComplete()
        {
            return View();
        }
    }
}
//添加属于验证的方法
//第一步，在model里找到存储数据类型的类，然后给每一个属性添加验证和报错的提示信息
//因为数据最先通过post请求传到[httppost]Index,所以利用系统自带的ModelState.IsValid验证传输的数据是否符合数据验证，若符合，则传到下一个界面，若不符合，则回到最初界面
//在第一个含表单的View视图中先添加引用，@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers，引用视图验证
//在表单下面添加<div asp-validation-summary="All" class="text-danger"></div>，表示显示所有错误的验证信息
//找到具体的控件添加对应的代码，所有asp为前缀的代码，表示如果不通过数据验证会提示对应的信息。
//
//