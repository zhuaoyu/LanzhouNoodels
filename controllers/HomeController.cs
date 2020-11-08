using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lanzhoubeefNoodefs.Models;// 4.1
using Microsoft.AspNetCore.Mvc;
using lanzhoubeefNoodefs.ViewModels;//4.1

namespace lanzhoubeefNoodefs.controllers
{
   //[Route("Home1")]
    public class HomeController : Controller
    {
        private INoodleRepository noodleRepository;//5.1步，创建一个私有接口类成员变量，需要using
        private IFeedbackRepository feedbackRepository;//4.2 创建需要的私有接口类成员变量
        public HomeController(INoodleRepository noodle,IFeedbackRepository feedbac)//5.2步，创建一个控制器的构造函数并进行赋值。//4.3在构造函数中对所有需要的私有接口类进行赋值
        {
            noodleRepository = noodle;
            feedbackRepository = feedbac;
        }
        public ActionResult Index()//5.4步，创建不使用模板的视图，并在视图里写代码调用数据
        {
            //  var noodles=noodleRepository.GetAllNoodles();//5.3:得到面条所有数据并传值
            // return View(noodles);//5.3

            var viewmodle = new HomeViewModel()//4.4先引入需要用到的ViewModel
            {
                Feedbacks = feedbackRepository.GetALLFeedback().ToList(),//4.4获取的数据用Tolist转为列表格式
                Noodles=noodleRepository.GetAllNoodles().ToList()

            };//4.4注意这个有一个分号
            return View(viewmodle);//4.4
        }
        //[Route("Index")]
        public string about()
        {
            return "1234";
        }
        public IActionResult detail(int id)
        {
            return View(noodleRepository.GetNoodleById(id));
        }


    }
}
//第五步，显示数据，5.1步创建一个接口类私有变量。（需要using）
//5.2步，创建一个控制器的构造函数,并进行赋值
//5.3步。使用面条仓库
//5.4步，创建不使用模板的视图调用函数
//
//使用ViewModels进行数据的展示
//第四步，4.1  using 控制器名.Models 和 using 控制器名.ViewModels
//4.2 创建接口类的私有变量
//4.3 创建控制器的构造函数，并赋值（对所有需要用到的接口类进行赋值）
//4.4 使用ViewModels进行获取需要的值
//4.5转到对应的视图界面Index