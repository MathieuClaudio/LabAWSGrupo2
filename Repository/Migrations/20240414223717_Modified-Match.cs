using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedMatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Matches_IdClubB",
                table: "Matches",
                column: "IdClubB");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Clubs_IdClubB",
                table: "Matches",
                column: "IdClubB",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Clubs_IdClubB",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_IdClubB",
                table: "Matches");
        }
    }
}
