using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class Thirdly_DataSeed_Players : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Age", "ClubId", "FullName", "Number" },
                values: new object[,]
                {
                    { 1, 37, 1, "ROMERO Sergio", 1 },
                    { 2, 34, 1, "LEMA Cristian", 2 },
                    { 3, 25, 1, "SARACCHI Marcelo", 3 },
                    { 4, 34, 1, "FIGAL Nicolás", 4 },
                    { 5, 23, 1, "BULLAUDE Ezequiel", 5 },
                    { 6, 34, 1, "ROJO Marcos", 6 },
                    { 7, 21, 1, "ZEBALLOS Exequiel", 7 },
                    { 8, 32, 1, "FERNÁNDEZ Guillermo", 8 },
                    { 9, 34, 1, "BENEDETTO Darío", 9 },
                    { 10, 37, 1, "CAVANI Edison", 10 },
                    { 11, 34, 1, "JANSON Lucas", 11 },
                    { 12, 37, 2, "ARMANI Franco", 1 },
                    { 13, 21, 2, "BOSELLI Sebastián", 2 },
                    { 14, 33, 2, "FUNES MORI Ramiro", 3 },
                    { 15, 35, 2, "FONSECA Nicolás", 4 },
                    { 16, 30, 2, "KRANEVITTER Matías", 5 },
                    { 17, 26, 2, "MARTÍNEZ David", 6 },
                    { 18, 27, 2, "PALAVECINO Agustín", 8 },
                    { 19, 31, 2, "LANZINI Manuel", 10 },
                    { 20, 28, 2, "DÍAZ Enzo", 13 },
                    { 21, 32, 2, "GONZÁLEZ PIREZ Leandro", 14 },
                    { 22, 25, 2, "HERRERA Marcelo Andrés", 14 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 22);
        }
    }
}
