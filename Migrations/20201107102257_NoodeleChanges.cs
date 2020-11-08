using Microsoft.EntityFrameworkCore.Migrations;

namespace lanzhoubeefNoodefs.Migrations
{
    public partial class NoodeleChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)//第二次迁移，增加了一个列
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInStock",
                table: "Noodles",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInStock",
                table: "Noodles");
        }
    }
}
