using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class Thirdly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Clubs_IdClub",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "IdClub",
                table: "Players",
                newName: "ClubId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_IdClub",
                table: "Players",
                newName: "IX_Players_ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Clubs_ClubId",
                table: "Players",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Clubs_ClubId",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "ClubId",
                table: "Players",
                newName: "IdClub");

            migrationBuilder.RenameIndex(
                name: "IX_Players_ClubId",
                table: "Players",
                newName: "IX_Players_IdClub");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Clubs_IdClub",
                table: "Players",
                column: "IdClub",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
