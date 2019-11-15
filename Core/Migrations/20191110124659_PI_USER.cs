using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class PI_USER : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MatriculaAnunciante",
                table: "Produtos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Lido",
                table: "ProdutoInteresses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Matricula",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatriculaAnunciante",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Lido",
                table: "ProdutoInteresses");

            migrationBuilder.DropColumn(
                name: "Matricula",
                table: "AspNetUsers");
        }
    }
}
