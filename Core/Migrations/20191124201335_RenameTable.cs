using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class RenameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SituacaoProduto_SituacaoMotivoCancelamento_MotivoCancelamentoId",
                table: "SituacaoProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_SituacaoProduto_Produtos_ProdutoId",
                table: "SituacaoProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_SituacaoProduto_SolicitacaoStatus_StatusId",
                table: "SituacaoProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_SituacaoProduto_AspNetUsers_UsuarioAnuncianteId",
                table: "SituacaoProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_SituacaoProduto_AspNetUsers_UsuarioSolicitanteId",
                table: "SituacaoProduto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SituacaoProduto",
                table: "SituacaoProduto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SituacaoMotivoCancelamento",
                table: "SituacaoMotivoCancelamento");

            migrationBuilder.RenameTable(
                name: "SituacaoProduto",
                newName: "SolicitacaoProduto");

            migrationBuilder.RenameTable(
                name: "SituacaoMotivoCancelamento",
                newName: "TiposMotivoCancelamento");

            migrationBuilder.RenameIndex(
                name: "IX_SituacaoProduto_UsuarioSolicitanteId",
                table: "SolicitacaoProduto",
                newName: "IX_SolicitacaoProduto_UsuarioSolicitanteId");

            migrationBuilder.RenameIndex(
                name: "IX_SituacaoProduto_UsuarioAnuncianteId",
                table: "SolicitacaoProduto",
                newName: "IX_SolicitacaoProduto_UsuarioAnuncianteId");

            migrationBuilder.RenameIndex(
                name: "IX_SituacaoProduto_StatusId",
                table: "SolicitacaoProduto",
                newName: "IX_SolicitacaoProduto_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_SituacaoProduto_ProdutoId",
                table: "SolicitacaoProduto",
                newName: "IX_SolicitacaoProduto_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_SituacaoProduto_MotivoCancelamentoId",
                table: "SolicitacaoProduto",
                newName: "IX_SolicitacaoProduto_MotivoCancelamentoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolicitacaoProduto",
                table: "SolicitacaoProduto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiposMotivoCancelamento",
                table: "TiposMotivoCancelamento",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoProduto_TiposMotivoCancelamento_MotivoCancelamentoId",
                table: "SolicitacaoProduto",
                column: "MotivoCancelamentoId",
                principalTable: "TiposMotivoCancelamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoProduto_Produtos_ProdutoId",
                table: "SolicitacaoProduto",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoProduto_SolicitacaoStatus_StatusId",
                table: "SolicitacaoProduto",
                column: "StatusId",
                principalTable: "SolicitacaoStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoProduto_AspNetUsers_UsuarioAnuncianteId",
                table: "SolicitacaoProduto",
                column: "UsuarioAnuncianteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoProduto_AspNetUsers_UsuarioSolicitanteId",
                table: "SolicitacaoProduto",
                column: "UsuarioSolicitanteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoProduto_TiposMotivoCancelamento_MotivoCancelamentoId",
                table: "SolicitacaoProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoProduto_Produtos_ProdutoId",
                table: "SolicitacaoProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoProduto_SolicitacaoStatus_StatusId",
                table: "SolicitacaoProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoProduto_AspNetUsers_UsuarioAnuncianteId",
                table: "SolicitacaoProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoProduto_AspNetUsers_UsuarioSolicitanteId",
                table: "SolicitacaoProduto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TiposMotivoCancelamento",
                table: "TiposMotivoCancelamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolicitacaoProduto",
                table: "SolicitacaoProduto");

            migrationBuilder.RenameTable(
                name: "TiposMotivoCancelamento",
                newName: "SituacaoMotivoCancelamento");

            migrationBuilder.RenameTable(
                name: "SolicitacaoProduto",
                newName: "SituacaoProduto");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitacaoProduto_UsuarioSolicitanteId",
                table: "SituacaoProduto",
                newName: "IX_SituacaoProduto_UsuarioSolicitanteId");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitacaoProduto_UsuarioAnuncianteId",
                table: "SituacaoProduto",
                newName: "IX_SituacaoProduto_UsuarioAnuncianteId");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitacaoProduto_StatusId",
                table: "SituacaoProduto",
                newName: "IX_SituacaoProduto_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitacaoProduto_ProdutoId",
                table: "SituacaoProduto",
                newName: "IX_SituacaoProduto_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitacaoProduto_MotivoCancelamentoId",
                table: "SituacaoProduto",
                newName: "IX_SituacaoProduto_MotivoCancelamentoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SituacaoMotivoCancelamento",
                table: "SituacaoMotivoCancelamento",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SituacaoProduto",
                table: "SituacaoProduto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SituacaoProduto_SituacaoMotivoCancelamento_MotivoCancelamentoId",
                table: "SituacaoProduto",
                column: "MotivoCancelamentoId",
                principalTable: "SituacaoMotivoCancelamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SituacaoProduto_Produtos_ProdutoId",
                table: "SituacaoProduto",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SituacaoProduto_SolicitacaoStatus_StatusId",
                table: "SituacaoProduto",
                column: "StatusId",
                principalTable: "SolicitacaoStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SituacaoProduto_AspNetUsers_UsuarioAnuncianteId",
                table: "SituacaoProduto",
                column: "UsuarioAnuncianteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SituacaoProduto_AspNetUsers_UsuarioSolicitanteId",
                table: "SituacaoProduto",
                column: "UsuarioSolicitanteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
