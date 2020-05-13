using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACWebApp.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PropietarioId = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    SenasParticulares = table.Column<string>(nullable: true),
                    Zona = table.Column<string>(nullable: true),
                    Chip = table.Column<string>(nullable: true),
                    NumeroChip = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    FechaDefuncion = table.Column<DateTime>(nullable: true),
                    MotivoDefuncion = table.Column<string>(nullable: true),
                    Observacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Propietarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PrimerNombre = table.Column<string>(nullable: false),
                    SegundoNombre = table.Column<string>(nullable: true),
                    PrimerApellido = table.Column<string>(nullable: false),
                    SegundoApellido = table.Column<string>(nullable: true),
                    TipoIdentificacion = table.Column<string>(nullable: false),
                    Identificacion = table.Column<string>(nullable: false),
                    Ciudad = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Ocupacion = table.Column<string>(nullable: true),
                    Telefono1 = table.Column<string>(nullable: false),
                    Telefono2 = table.Column<string>(nullable: true),
                    Celular1 = table.Column<string>(nullable: false),
                    Celular2 = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Observacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropietarioPacientes",
                columns: table => new
                {
                    PacienteId = table.Column<Guid>(nullable: false),
                    PropietarioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropietarioPacientes", x => new { x.PacienteId, x.PropietarioId });
                    table.ForeignKey(
                        name: "FK_PropietarioPacientes_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropietarioPacientes_Propietarios_PropietarioId",
                        column: x => x.PropietarioId,
                        principalTable: "Propietarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropietarioPacientes_PropietarioId",
                table: "PropietarioPacientes",
                column: "PropietarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropietarioPacientes");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Propietarios");
        }
    }
}
