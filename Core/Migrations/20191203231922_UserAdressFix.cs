using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class UserAdressFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddressComplement",
                table: "AspNetUsers",
                newName: "City");

            migrationBuilder.AlterColumn<int>(
                name: "AddressNumber",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "AspNetUsers",
                newName: "AddressComplement");

            migrationBuilder.AlterColumn<string>(
                name: "AddressNumber",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
