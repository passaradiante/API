using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Situacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SituacaoMotivoCancelamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacaoMotivoCancelamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SituacaoStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacaoStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SituacaoProduto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProdutoId = table.Column<int>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false),
                    UsuarioAnuncianteId = table.Column<string>(nullable: true),
                    UsuarioSolicitanteId = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: true),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataTermino = table.Column<DateTime>(nullable: false),
                    MotivoCancelamentoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacaoProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SituacaoProduto_SituacaoMotivoCancelamento_MotivoCancelamentoId",
                        column: x => x.MotivoCancelamentoId,
                        principalTable: "SituacaoMotivoCancelamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SituacaoProduto_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SituacaoProduto_SituacaoStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "SituacaoStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SituacaoProduto_AspNetUsers_UsuarioAnuncianteId",
                        column: x => x.UsuarioAnuncianteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SituacaoProduto_AspNetUsers_UsuarioSolicitanteId",
                        column: x => x.UsuarioSolicitanteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SituacaoProduto_MotivoCancelamentoId",
                table: "SituacaoProduto",
                column: "MotivoCancelamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_SituacaoProduto_ProdutoId",
                table: "SituacaoProduto",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_SituacaoProduto_StatusId",
                table: "SituacaoProduto",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SituacaoProduto_UsuarioAnuncianteId",
                table: "SituacaoProduto",
                column: "UsuarioAnuncianteId");

            migrationBuilder.CreateIndex(
                name: "IX_SituacaoProduto_UsuarioSolicitanteId",
                table: "SituacaoProduto",
                column: "UsuarioSolicitanteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SituacaoProduto");

            migrationBuilder.DropTable(
                name: "SituacaoMotivoCancelamento");

            migrationBuilder.DropTable(
                name: "SituacaoStatus");
        }
    }
}
