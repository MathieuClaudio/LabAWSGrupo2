using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stadiums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadiums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clubs_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocalClubId = table.Column<int>(type: "int", nullable: false),
                    VisitorClubId = table.Column<int>(type: "int", nullable: false),
                    IdTournament = table.Column<int>(type: "int", nullable: false),
                    IdStadium = table.Column<int>(type: "int", nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Clubs_LocalClubId",
                        column: x => x.LocalClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Clubs_VisitorClubId",
                        column: x => x.VisitorClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Stadiums_IdStadium",
                        column: x => x.IdStadium,
                        principalTable: "Stadiums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id");
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

            migrationBuilder.CreateTable(
                name: "Standings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    IdClub = table.Column<int>(type: "int", nullable: false),
                    TournamentId1 = table.Column<int>(type: "int", nullable: true)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Standings_Tournaments_TournamentId1",
                        column: x => x.TournamentId1,
                        principalTable: "Tournaments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MatchResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    LocalClubGoals = table.Column<int>(type: "int", nullable: false),
                    VisitorClubGoals = table.Column<int>(type: "int", nullable: false),
                    StandingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchResults_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchResults_Standings_StandingId",
                        column: x => x.StandingId,
                        principalTable: "Standings",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "Name", "TournamentId" },
                values: new object[,]
                {
                    { 1, "Boca Juniors", null },
                    { 2, "River Plate", null },
                    { 3, "Argentinos Juniors", null },
                    { 4, "Belgrano", null },
                    { 5, "Estudiantes", null },
                    { 6, "Huracán", null },
                    { 7, "Independiente", null },
                    { 8, "Lanús", null },
                    { 9, "Tigre", null },
                    { 10, "Vélez", null }
                });

            migrationBuilder.InsertData(
                table: "Stadiums",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Monumental" },
                    { 2, "Libertadores de América" },
                    { 3, "Malvinas Argentinas" },
                    { 4, "Nueva Chicago" },
                    { 5, "Diego Armando Maradona" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "EndDate", "Name", "StartDate" },
                values: new object[] { 1, new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apertura 2024", new DateTime(2024, 4, 28, 20, 43, 41, 183, DateTimeKind.Local).AddTicks(9926) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "Claudio", "123", "claudio" },
                    { 2, "Nicolás", "123", "nicolas" },
                    { 3, "Emanuel", "123", "emanuel" }
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "IdStadium", "IdTournament", "LocalClubId", "MatchDate", "TournamentId", "VisitorClubId" },
                values: new object[,]
                {
                    { 1, 1, 0, 1, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2 },
                    { 2, 1, 0, 3, new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4 }
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

            migrationBuilder.InsertData(
                table: "Standings",
                columns: new[] { "Id", "IdClub", "TournamentId", "TournamentId1" },
                values: new object[,]
                {
                    { 1, 1, 1, null },
                    { 2, 2, 1, null },
                    { 3, 3, 1, null },
                    { 4, 4, 1, null }
                });

            migrationBuilder.InsertData(
                table: "MatchResults",
                columns: new[] { "Id", "LocalClubGoals", "MatchId", "StandingId", "VisitorClubGoals" },
                values: new object[,]
                {
                    { 1, 3, 1, null, 1 },
                    { 2, 1, 2, null, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_TournamentId",
                table: "Clubs",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_IdStadium",
                table: "Matches",
                column: "IdStadium");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_LocalClubId",
                table: "Matches",
                column: "LocalClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TournamentId",
                table: "Matches",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_VisitorClubId",
                table: "Matches",
                column: "VisitorClubId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchResults_MatchId",
                table: "MatchResults",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchResults_StandingId",
                table: "MatchResults",
                column: "StandingId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_ClubId",
                table: "Players",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Standings_IdClub",
                table: "Standings",
                column: "IdClub");

            migrationBuilder.CreateIndex(
                name: "IX_Standings_TournamentId",
                table: "Standings",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Standings_TournamentId1",
                table: "Standings",
                column: "TournamentId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchResults");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Standings");

            migrationBuilder.DropTable(
                name: "Stadiums");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Tournaments");
        }
    }
}
