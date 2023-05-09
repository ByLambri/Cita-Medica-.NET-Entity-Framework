using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace citamedica.Migrations
{
    /// <inheritdoc />
    public partial class b : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id_usuario = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clave = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "medicos",
                columns: table => new
                {
                    Id_usuario = table.Column<long>(type: "bigint", nullable: false),
                    numColegiado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicos", x => x.Id_usuario);
                    table.ForeignKey(
                        name: "FK_medicos_usuarios_Id_usuario",
                        column: x => x.Id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "Id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pacientes",
                columns: table => new
                {
                    Id_usuario = table.Column<long>(type: "bigint", nullable: false),
                    NSS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numTarjeta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pacientes", x => x.Id_usuario);
                    table.ForeignKey(
                        name: "FK_pacientes_usuarios_Id_usuario",
                        column: x => x.Id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "Id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "citas",
                columns: table => new
                {
                    id_cita = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    motivoCita = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicoId = table.Column<long>(type: "bigint", nullable: false),
                    PacienteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_citas", x => x.id_cita);
                    table.ForeignKey(
                        name: "FK_citas_medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "medicos",
                        principalColumn: "Id_usuario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_citas_pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "pacientes",
                        principalColumn: "Id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicosPacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicoId = table.Column<long>(type: "bigint", nullable: false),
                    PacienteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicosPacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicosPacientes_medicos_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "medicos",
                        principalColumn: "Id_usuario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicosPacientes_pacientes_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "pacientes",
                        principalColumn: "Id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "diagnosticos",
                columns: table => new
                {
                    id_Diagnostico = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valoracionEspecialista = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enfermedad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CitaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diagnosticos", x => x.id_Diagnostico);
                    table.ForeignKey(
                        name: "FK_diagnosticos_citas_CitaId",
                        column: x => x.CitaId,
                        principalTable: "citas",
                        principalColumn: "id_cita",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_citas_MedicoId",
                table: "citas",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_citas_PacienteId",
                table: "citas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_diagnosticos_CitaId",
                table: "diagnosticos",
                column: "CitaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicosPacientes_MedicoId",
                table: "MedicosPacientes",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicosPacientes_PacienteId",
                table: "MedicosPacientes",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "diagnosticos");

            migrationBuilder.DropTable(
                name: "MedicosPacientes");

            migrationBuilder.DropTable(
                name: "citas");

            migrationBuilder.DropTable(
                name: "medicos");

            migrationBuilder.DropTable(
                name: "pacientes");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
