using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightsManager.Migrations
{
    public partial class AddSchedules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HorarioId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_HorarioId",
                table: "Vuelos",
                column: "HorarioId");

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
                name: "FK_Vuelos_Horarios_HorarioId",
                table: "Vuelos");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropIndex(
                name: "IX_Vuelos_HorarioId",
                table: "Vuelos");

            migrationBuilder.DropColumn(
                name: "HorarioId",
                table: "Vuelos");
        }
    }
}
