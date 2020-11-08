using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lanzhoubeefNoodefs.Migrations
{



    //这个文件夹里，每一次需要改变数据库属性等操作都会生成一个这样的文件
    //这些文件帮我们恢复数据库的结构，也是数据库变迁的历史记录

    public partial class InitialMigration : Migration
    {//这是第一次的数据迁移代码 
        protected override void Up(MigrationBuilder migrationBuilder)//执行数据库变化的函数
        {
            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    emall = table.Column<string>(maxLength: 50, nullable: false),
                    createdateutc = table.Column<DateTime>(nullable: false),
                    message = table.Column<string>(maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Noodles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    shortDescription = table.Column<string>(nullable: true),
                    longDescription = table.Column<string>(nullable: true),
                    price = table.Column<decimal>(nullable: false),
                    urlimage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noodles", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)//用于删掉两张表
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Noodles");
        }
    }
}
