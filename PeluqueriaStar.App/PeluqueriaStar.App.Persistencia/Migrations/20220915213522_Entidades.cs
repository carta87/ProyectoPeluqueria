using Microsoft.EntityFrameworkCore.Migrations;

namespace PeluqueriaStar.App.Persistencia.Migrations
{
    public partial class Entidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HorarioEstelista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Horario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioEstelista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Membresia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivadaMembresia = table.Column<bool>(type: "bit", nullable: false),
                    ValorDescuento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membresia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiciosOfrecer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorServicio = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciosOfrecer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CitaAsignada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCita = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HorarioCita = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MembresiaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitaAsignada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CitaAsignada_Membresia_MembresiaId",
                        column: x => x.MembresiaId,
                        principalTable: "Membresia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoSalud = table.Column<bool>(type: "bit", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Administrador_CitaAsignadaId = table.Column<int>(type: "int", nullable: true),
                    MembresiaId = table.Column<int>(type: "int", nullable: true),
                    Administrador_ServiciosOfrecerId = table.Column<int>(type: "int", nullable: true),
                    Administrador_HorarioEstelistaId = table.Column<int>(type: "int", nullable: true),
                    Dirrecion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: true),
                    Genero = table.Column<int>(type: "int", nullable: true),
                    EstelistaId = table.Column<int>(type: "int", nullable: true),
                    CitaAsignadaId = table.Column<int>(type: "int", nullable: true),
                    TarjetaProfesional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HorarioEstelistaId = table.Column<int>(type: "int", nullable: true),
                    ServiciosOfrecerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persona_CitaAsignada_Administrador_CitaAsignadaId",
                        column: x => x.Administrador_CitaAsignadaId,
                        principalTable: "CitaAsignada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persona_CitaAsignada_CitaAsignadaId",
                        column: x => x.CitaAsignadaId,
                        principalTable: "CitaAsignada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persona_HorarioEstelista_Administrador_HorarioEstelistaId",
                        column: x => x.Administrador_HorarioEstelistaId,
                        principalTable: "HorarioEstelista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persona_HorarioEstelista_HorarioEstelistaId",
                        column: x => x.HorarioEstelistaId,
                        principalTable: "HorarioEstelista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persona_Membresia_MembresiaId",
                        column: x => x.MembresiaId,
                        principalTable: "Membresia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persona_Persona_EstelistaId",
                        column: x => x.EstelistaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persona_ServiciosOfrecer_Administrador_ServiciosOfrecerId",
                        column: x => x.Administrador_ServiciosOfrecerId,
                        principalTable: "ServiciosOfrecer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persona_ServiciosOfrecer_ServiciosOfrecerId",
                        column: x => x.ServiciosOfrecerId,
                        principalTable: "ServiciosOfrecer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CitaAsignada_MembresiaId",
                table: "CitaAsignada",
                column: "MembresiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_Administrador_CitaAsignadaId",
                table: "Persona",
                column: "Administrador_CitaAsignadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_Administrador_HorarioEstelistaId",
                table: "Persona",
                column: "Administrador_HorarioEstelistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_Administrador_ServiciosOfrecerId",
                table: "Persona",
                column: "Administrador_ServiciosOfrecerId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_CitaAsignadaId",
                table: "Persona",
                column: "CitaAsignadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_EstelistaId",
                table: "Persona",
                column: "EstelistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_HorarioEstelistaId",
                table: "Persona",
                column: "HorarioEstelistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_MembresiaId",
                table: "Persona",
                column: "MembresiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_ServiciosOfrecerId",
                table: "Persona",
                column: "ServiciosOfrecerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "CitaAsignada");

            migrationBuilder.DropTable(
                name: "HorarioEstelista");

            migrationBuilder.DropTable(
                name: "ServiciosOfrecer");

            migrationBuilder.DropTable(
                name: "Membresia");
        }
    }
}
