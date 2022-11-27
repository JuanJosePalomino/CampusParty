using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusParty.Migrations
{
    public partial class InitDBv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Estadia",
                table: "UsuarioEventos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaNacimiento" },
                values: new object[] { "$2a$10$LB4qPS7Ca1/rimNtfwWZF.DKCT38oALID/G/6GHROvbGZMvJJDFea", new DateTime(2022, 11, 26, 22, 10, 40, 184, DateTimeKind.Local).AddTicks(1527) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estadia",
                table: "UsuarioEventos");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaNacimiento" },
                values: new object[] { "$2a$10$0jhvQMyUv6ygy.Z7Fv/TpOzmdYxcQL3QK9UTBEayUAS0/oeTMHDcq", new DateTime(2022, 11, 20, 14, 37, 13, 25, DateTimeKind.Local).AddTicks(518) });
        }
    }
}
