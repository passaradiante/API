using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class ProdutoInteresse_Agoravai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoInteresses_AspNetUsers_UsuarioId",
                table: "ProdutoInteresses");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "ProdutoInteresses",
                newName: "UsuarioSolicitanteId");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoInteresses_UsuarioId",
                table: "ProdutoInteresses",
                newName: "IX_ProdutoInteresses_UsuarioSolicitanteId");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioAnuncianteId",
                table: "ProdutoInteresses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoInteresses_UsuarioAnuncianteId",
                table: "ProdutoInteresses",
                column: "UsuarioAnuncianteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoInteresses_AspNetUsers_UsuarioAnuncianteId",
                table: "ProdutoInteresses",
                column: "UsuarioAnuncianteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoInteresses_AspNetUsers_UsuarioSolicitanteId",
                table: "ProdutoInteresses",
                column: "UsuarioSolicitanteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoInteresses_AspNetUsers_UsuarioAnuncianteId",
                table: "ProdutoInteresses");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoInteresses_AspNetUsers_UsuarioSolicitanteId",
                table: "ProdutoInteresses");

            migrationBuilder.DropIndex(
                name: "IX_ProdutoInteresses_UsuarioAnuncianteId",
                table: "ProdutoInteresses");

            migrationBuilder.DropColumn(
                name: "UsuarioAnuncianteId",
                table: "ProdutoInteresses");

            migrationBuilder.RenameColumn(
                name: "UsuarioSolicitanteId",
                table: "ProdutoInteresses",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoInteresses_UsuarioSolicitanteId",
                table: "ProdutoInteresses",
                newName: "IX_ProdutoInteresses_UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoInteresses_AspNetUsers_UsuarioId",
                table: "ProdutoInteresses",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
