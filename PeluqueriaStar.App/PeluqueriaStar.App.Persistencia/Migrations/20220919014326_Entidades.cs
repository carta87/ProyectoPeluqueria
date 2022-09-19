using Microsoft.EntityFrameworkCore.Migrations;

namespace PeluqueriaStar.App.Persistencia.Migrations
{
    public partial class Entidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoSalud = table.Column<bool>(type: "bit", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Administrador_EstelistaId = table.Column<int>(type: "int", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    ServiciosOfrecerId = table.Column<int>(type: "int", nullable: true),
                    HorarioEstelistaId = table.Column<int>(type: "int", nullable: true),
                    Dirrecion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: true),
                    Genero = table.Column<int>(type: "int", nullable: true),
                    Membresia = table.Column<bool>(type: "bit", nullable: true),
                    CantidadCitas = table.Column<int>(type: "int", nullable: true),
                    EstelistaId = table.Column<int>(type: "int", nullable: true),
                    TarjetaProfesional = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persona_Persona_Administrador_EstelistaId",
                        column: x => x.Administrador_EstelistaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persona_Persona_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persona_Persona_EstelistaId",
                        column: x => x.EstelistaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HorarioEstelista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disponibilidad = table.Column<bool>(type: "bit", nullable: false),
                    Fecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Horario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    EstelistaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioEstelista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HorarioEstelista_Persona_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HorarioEstelista_Persona_EstelistaId",
                        column: x => x.EstelistaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiciosOfrecer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorServicio = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    EstelistaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciosOfrecer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiciosOfrecer_Persona_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiciosOfrecer_Persona_EstelistaId",
                        column: x => x.EstelistaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HorarioEstelista_ClienteId",
                table: "HorarioEstelista",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioEstelista_EstelistaId",
                table: "HorarioEstelista",
                column: "EstelistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_Administrador_EstelistaId",
                table: "Persona",
                column: "Administrador_EstelistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_ClienteId",
                table: "Persona",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_EstelistaId",
                table: "Persona",
                column: "EstelistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_HorarioEstelistaId",
                table: "Persona",
                column: "HorarioEstelistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_ServiciosOfrecerId",
                table: "Persona",
                column: "ServiciosOfrecerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosOfrecer_ClienteId",
                table: "ServiciosOfrecer",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosOfrecer_EstelistaId",
                table: "ServiciosOfrecer",
                column: "EstelistaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_HorarioEstelista_HorarioEstelistaId",
                table: "Persona",
                column: "HorarioEstelistaId",
                principalTable: "HorarioEstelista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_ServiciosOfrecer_ServiciosOfrecerId",
                table: "Persona",
                column: "ServiciosOfrecerId",
                principalTable: "ServiciosOfrecer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HorarioEstelista_Persona_ClienteId",
                table: "HorarioEstelista");

            migrationBuilder.DropForeignKey(
                name: "FK_HorarioEstelista_Persona_EstelistaId",
                table: "HorarioEstelista");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiciosOfrecer_Persona_ClienteId",
                table: "ServiciosOfrecer");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiciosOfrecer_Persona_EstelistaId",
                table: "ServiciosOfrecer");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "HorarioEstelista");

            migrationBuilder.DropTable(
                name: "ServiciosOfrecer");
        }
    }
}
