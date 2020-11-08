using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lanzhoubeefNoodefs.Models;
using Microsoft.AspNetCore.Mvc;

namespace lanzhoubeefNoodefs.controllers
{
   // [Route("admin/[controller]/[action]")]//增加url验证
    public class NoodleController : Controller//类只能是public，不然HTTP请求访问不到
    {
       

        //ActionResult的意思在于根据返回的内容自动匹配类型。
        //Content定义的类型，可为string，可为json等。
        //例子
      //  public ActionResult Index() 
       // {
       //     return Content("hello world");  content为返回数据的类型
       // }
        public IList<string> Index()//设计http请求的，都要改为public
        {
            return new List<string> {"大白菜","太白菜","菜菜" };
        }
        public ActionResult shitu()
        {
            return View();
        }
    }
}

