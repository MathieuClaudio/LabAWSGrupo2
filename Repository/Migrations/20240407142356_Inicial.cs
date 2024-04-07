using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Age = table.Column<int>(type: "int", precision: 2, scale: 0, nullable: false),
                    Number = table.Column<int>(type: "int", precision: 2, scale: 0, nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Boca Juniors" },
                    { 2, "River Plate" },
                    { 3, "Argentinos Juniors" },
                    { 4, "Belgrano" },
                    { 5, "Estudiantes" },
                    { 6, "Huracán" },
                    { 7, "Independiente" },
                    { 8, "Lanús" },
                    { 9, "Tigre" },
                    { 10, "Vélez" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Players_ClubId",
                table: "Players",
                column: "ClubId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Clubs");
        }
    }
}
