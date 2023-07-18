using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_FrontEnd_BackEnd_Project.Migrations
{
    public partial class CreateProductTabless : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Background_BackgroundId",
                table: "Category");

            migrationBuilder.DropTable(
                name: "Background");

            migrationBuilder.DropIndex(
                name: "IX_Category_BackgroundId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "BackgroundId",
                table: "Category");

            migrationBuilder.AddColumn<string>(
                name: "BackgroundColor",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundColor",
                table: "Category");

            migrationBuilder.AddColumn<int>(
                name: "BackgroundId",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Background",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackgroundImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Background", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_BackgroundId",
                table: "Category",
                column: "BackgroundId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Background_BackgroundId",
                table: "Category",
                column: "BackgroundId",
                principalTable: "Background",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
