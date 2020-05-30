using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACWebApp.Migrations
{
    public partial class Cuatro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropietarioPacientes_Owners_OwnerId",
                table: "PropietarioPacientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropietarioPacientes",
                table: "PropietarioPacientes");

            migrationBuilder.DropColumn(
                name: "PropietarioId",
                table: "PropietarioPacientes");

            migrationBuilder.DropColumn(
                name: "PropietarioId",
                table: "Pacientes");

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "PropietarioPacientes",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Pacientes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropietarioPacientes",
                table: "PropietarioPacientes",
                columns: new[] { "PacienteId", "OwnerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PropietarioPacientes_Owners_OwnerId",
                table: "PropietarioPacientes",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropietarioPacientes_Owners_OwnerId",
                table: "PropietarioPacientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropietarioPacientes",
                table: "PropietarioPacientes");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Pacientes");

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "PropietarioPacientes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "PropietarioId",
                table: "PropietarioPacientes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PropietarioId",
                table: "Pacientes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropietarioPacientes",
                table: "PropietarioPacientes",
                columns: new[] { "PacienteId", "PropietarioId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PropietarioPacientes_Owners_OwnerId",
                table: "PropietarioPacientes",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
