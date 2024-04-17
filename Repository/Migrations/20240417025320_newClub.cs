using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class newClub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Age", "ClubId", "FullName", "Number" },
                values: new object[,]
                {
                    { 23, 34, 3, "Diego Rodríguezs", 50 },
                    { 24, 34, 3, "Fernando Meza", 18 },
                    { 25, 24, 3, "Francisco Álvarez", 16 },
                    { 26, 31, 3, "Jonathan Galván", 19 },
                    { 27, 20, 3, "Román Vega", 6 },
                    { 28, 22, 3, "Alan Lescano ", 22 },
                    { 29, 26, 3, "Franco Moyano", 17 },
                    { 30, 30, 3, "Nicolás Oroz", 21 },
                    { 31, 20, 3, "José Herrera", 26 },
                    { 32, 22, 3, "Luciano Gondou", 32 },
                    { 33, 25, 3, "Maximiliano Romero", 9 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 33);
        }
    }
}
