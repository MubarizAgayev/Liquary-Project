using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_FrontEnd_BackEnd_Project.Migrations
{
    public partial class UpdateBlogTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Blog");
        }
    }
}
