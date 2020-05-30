using Microsoft.EntityFrameworkCore.Migrations;

namespace ACWebApp.Migrations
{
    public partial class Dos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nit",
                table: "Companies",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 12);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Companies",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "Companies",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Companies");

            migrationBuilder.AlterColumn<int>(
                name: "Nit",
                table: "Companies",
                type: "int",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 12);
        }
    }
}
