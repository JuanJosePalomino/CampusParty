using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusParty.Migrations
{
    public partial class InitDBv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaNacimiento" },
                values: new object[] { "$2a$10$q/yp5XqJB6GCr/TEuzLsMOHnn.QmpSq7Isby.zy6N2Gl2agwPYDwm", new DateTime(2022, 11, 26, 22, 15, 31, 117, DateTimeKind.Local).AddTicks(8492) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                columns: new[] { "Contraseña", "FechaNacimiento" },
                values: new object[] { "$2a$10$LB4qPS7Ca1/rimNtfwWZF.DKCT38oALID/G/6GHROvbGZMvJJDFea", new DateTime(2022, 11, 26, 22, 10, 40, 184, DateTimeKind.Local).AddTicks(1527) });
        }
    }
}
