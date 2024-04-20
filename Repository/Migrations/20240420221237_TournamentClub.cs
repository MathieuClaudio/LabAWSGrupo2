using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class TournamentClub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_Tournaments_TournamentId",
                table: "Clubs");

            migrationBuilder.DropTable(
                name: "Standings");

            migrationBuilder.DropIndex(
                name: "IX_Clubs_TournamentId",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "TournamentId",
                table: "Clubs");

            migrationBuilder.AddColumn<int>(
                name: "IdTournament",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TournamentsClubs",
                columns: table => new
                {
                    IdClub = table.Column<int>(type: "int", nullable: false),
                    IdTournament = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    MatchesPlayed = table.Column<int>(type: "int", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    Loses = table.Column<int>(type: "int", nullable: false),
                    Draws = table.Column<int>(type: "int", nullable: false),
                    Goals = table.Column<int>(type: "int", nullable: false),
                    GoalsAgainst = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentsClubs", x => new { x.IdClub, x.IdTournament });
                    table.ForeignKey(
                        name: "FK_TournamentsClubs_Clubs_IdClub",
                        column: x => x.IdClub,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TournamentsClubs_Tournaments_IdTournament",
                        column: x => x.IdTournament,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 1,
                column: "IdTournament",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "Id",
                keyValue: 2,
                column: "IdTournament",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TournamentsClubs_IdTournament",
                table: "TournamentsClubs",
                column: "IdTournament");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TournamentsClubs");

            migrationBuilder.DropColumn(
                name: "IdTournament",
                table: "Matches");

            migrationBuilder.AddColumn<int>(
                name: "TournamentId",
                table: "Clubs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Standings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClub = table.Column<int>(type: "int", nullable: false),
                    MatchesPlayed = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Standings_Clubs_IdClub",
                        column: x => x.IdClub,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Standings_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 1,
                column: "TournamentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 2,
                column: "TournamentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 3,
                column: "TournamentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 4,
                column: "TournamentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 5,
                column: "TournamentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 6,
                column: "TournamentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 7,
                column: "TournamentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 8,
                column: "TournamentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 9,
                column: "TournamentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clubs",
                keyColumn: "Id",
                keyValue: 10,
                column: "TournamentId",
                value: null);

            migrationBuilder.InsertData(
                table: "Standings",
                columns: new[] { "Id", "IdClub", "MatchesPlayed", "Points", "Position", "TournamentId" },
                values: new object[,]
                {
                    { 1, 1, 6, 12, 1, null },
                    { 2, 2, 5, 10, 2, null },
                    { 3, 3, 4, 8, 3, null },
                    { 4, 4, 4, 7, 4, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_TournamentId",
                table: "Clubs",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Standings_IdClub",
                table: "Standings",
                column: "IdClub");

            migrationBuilder.CreateIndex(
                name: "IX_Standings_TournamentId",
                table: "Standings",
                column: "TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_Tournaments_TournamentId",
                table: "Clubs",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id");
        }
    }
}
