using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddMatches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdClubA = table.Column<int>(type: "int", nullable: false),
                    IdClubB = table.Column<int>(type: "int", nullable: false),
                    IdStadium = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Clubs_IdClubA",
                        column: x => x.IdClubA,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Stadiums_IdStadium",
                        column: x => x.IdStadium,
                        principalTable: "Stadiums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "IdClubA", "IdClubB", "IdStadium", "MatchDate", "Result" },
                values: new object[,]
                {
                    { 1, 1, 2, 1, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "1 a 0" },
                    { 2, 3, 4, 1, new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "3 a 1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_IdClubA",
                table: "Matches",
                column: "IdClubA");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_IdStadium",
                table: "Matches",
                column: "IdStadium");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
