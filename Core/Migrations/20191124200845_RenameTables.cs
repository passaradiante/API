using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class RenameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SituacaoProduto_SituacaoStatus_StatusId",
                table: "SituacaoProduto");

            migrationBuilder.DropTable(
                name: "SituacaoStatus");

            migrationBuilder.CreateTable(
                name: "SolicitacaoStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitacaoStatus", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SituacaoProduto_SolicitacaoStatus_StatusId",
                table: "SituacaoProduto",
                column: "StatusId",
                principalTable: "SolicitacaoStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SituacaoProduto_SolicitacaoStatus_StatusId",
                table: "SituacaoProduto");

            migrationBuilder.DropTable(
                name: "SolicitacaoStatus");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SituacaoProduto_SituacaoStatus_StatusId",
                table: "SituacaoProduto",
                column: "StatusId",
                principalTable: "SituacaoStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
