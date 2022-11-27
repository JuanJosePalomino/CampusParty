using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusParty.Migrations
{
    public partial class InitDBv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioEventos_Computadores_ComputadorId",
                table: "UsuarioEventos");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioEventos_ComputadorId",
                table: "UsuarioEventos");

            migrationBuilder.RenameColumn(
                name: "ComputadorId",
                table: "UsuarioEventos",
                newName: "EventoId");

            migrationBuilder.AddColumn<string>(
                name: "Computador",
                table: "UsuarioEventos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaNacimiento" },
                values: new object[] { "$2a$10$0jhvQMyUv6ygy.Z7Fv/TpOzmdYxcQL3QK9UTBEayUAS0/oeTMHDcq", new DateTime(2022, 11, 20, 14, 37, 13, 25, DateTimeKind.Local).AddTicks(518) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Computador",
                table: "UsuarioEventos");

            migrationBuilder.RenameColumn(
                name: "EventoId",
                table: "UsuarioEventos",
                newName: "ComputadorId");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaNacimiento" },
                values: new object[] { "$2a$10$5KkwjfoVGMLe84wSU/wpD.0hJJth6Pf/n7oh0CYJ378EwyUoLNgMy", new DateTime(2022, 11, 13, 16, 24, 36, 703, DateTimeKind.Local).AddTicks(663) });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEventos_ComputadorId",
                table: "UsuarioEventos",
                column: "ComputadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioEventos_Computadores_ComputadorId",
                table: "UsuarioEventos",
                column: "ComputadorId",
                principalTable: "Computadores",
                principalColumn: "ComputadorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
