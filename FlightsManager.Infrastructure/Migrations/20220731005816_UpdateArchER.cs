using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightsManager.Migrations
{
    public partial class UpdateArchER : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vuelos_Paises_PaisDestinoId",
                table: "Vuelos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vuelos_Paises_PaisPartidaId",
                table: "Vuelos");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropColumn(
                name: "HoraLlegada",
                table: "Vuelos");

            migrationBuilder.DropColumn(
                name: "HoraPartida",
                table: "Vuelos");

            migrationBuilder.RenameColumn(
                name: "PaisPartidaId",
                table: "Vuelos",
                newName: "HorarioId");

            migrationBuilder.RenameColumn(
                name: "PaisDestinoId",
                table: "Vuelos",
                newName: "AeropuertoPartidaId");

            migrationBuilder.RenameIndex(
                name: "IX_Vuelos_PaisPartidaId",
                table: "Vuelos",
                newName: "IX_Vuelos_HorarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Vuelos_PaisDestinoId",
                table: "Vuelos",
                newName: "IX_Vuelos_AeropuertoPartidaId");

            migrationBuilder.AddColumn<int>(
                name: "AeropuertoDestinoId",
                table: "Vuelos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoraPartida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraLlegada = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VueloId = table.Column<int>(type: "int", nullable: false),
                    PasajeroId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_AspNetUsers_PasajeroId",
                        column: x => x.PasajeroId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservas_Vuelos_VueloId",
                        column: x => x.VueloId,
                        principalTable: "Vuelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_AeropuertoDestinoId",
                table: "Vuelos",
                column: "AeropuertoDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_PasajeroId",
                table: "Reservas",
                column: "PasajeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_VueloId",
                table: "Reservas",
                column: "VueloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelos_Aeropuertos_AeropuertoDestinoId",
                table: "Vuelos",
                column: "AeropuertoDestinoId",
                principalTable: "Aeropuertos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelos_Aeropuertos_AeropuertoPartidaId",
                table: "Vuelos",
                column: "AeropuertoPartidaId",
                principalTable: "Aeropuertos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelos_Horarios_HorarioId",
                table: "Vuelos",
                column: "HorarioId",
                principalTable: "Horarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vuelos_Aeropuertos_AeropuertoDestinoId",
                table: "Vuelos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vuelos_Aeropuertos_AeropuertoPartidaId",
                table: "Vuelos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vuelos_Horarios_HorarioId",
                table: "Vuelos");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Vuelos_AeropuertoDestinoId",
                table: "Vuelos");

            migrationBuilder.DropColumn(
                name: "AeropuertoDestinoId",
                table: "Vuelos");

            migrationBuilder.RenameColumn(
                name: "HorarioId",
                table: "Vuelos",
                newName: "PaisPartidaId");

            migrationBuilder.RenameColumn(
                name: "AeropuertoPartidaId",
                table: "Vuelos",
                newName: "PaisDestinoId");

            migrationBuilder.RenameIndex(
                name: "IX_Vuelos_HorarioId",
                table: "Vuelos",
                newName: "IX_Vuelos_PaisPartidaId");

            migrationBuilder.RenameIndex(
                name: "IX_Vuelos_AeropuertoPartidaId",
                table: "Vuelos",
                newName: "IX_Vuelos_PaisDestinoId");

            migrationBuilder.AddColumn<DateTime>(
                name: "HoraLlegada",
                table: "Vuelos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "HoraPartida",
                table: "Vuelos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vueloId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Impuesto = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_Vuelos_vueloId",
                        column: x => x.vueloId,
                        principalTable: "Vuelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_vueloId",
                table: "Pagos",
                column: "vueloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelos_Paises_PaisDestinoId",
                table: "Vuelos",
                column: "PaisDestinoId",
                principalTable: "Paises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vuelos_Paises_PaisPartidaId",
                table: "Vuelos",
                column: "PaisPartidaId",
                principalTable: "Paises",
                principalColumn: "Id");
        }
    }
}
