using Microsoft.EntityFrameworkCore.Migrations;

namespace TCompany.Migrations
{
    public partial class updateimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgSrc",
                table: "Tours",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgSrc",
                table: "Tours");
        }
    }
}
