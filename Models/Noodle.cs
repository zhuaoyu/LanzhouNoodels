using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lanzhoubeefNoodefs.Models
{
    public class Noodle//面条的数据
    {
        public int ID { get; set; }//面条id
        public string name { get; set; }//面条名

        public string shortDescription { get; set; }//简介

        public string longDescription { get; set; }//介绍

        public decimal price { get; set; }//小数点后两位，价格

        public string urlimage { get; set; }//图片

        public bool IsInStock { get; set; }//判断是否还有库存
    }
}
//第一步，创建表需要的数据
//先在mode里创建所有数据的类型，如上所示
//添加类，选择接口，创建INoodleRespository


//当添加或者删除某些属性时
//添加|删除属性完成相关操作后，点击项目名称，右键，生成
//在顶部，打开视图，其他窗口，打开程序包管理控制器
//输入：add-migration 自定义个名字NoodeleChanges
//成功之后在Migration文件夹下又多了一个这次迁移的文件
//在程序包管理控制台输入：update-database
//当看到Done的时候，数据库就更新完毕了