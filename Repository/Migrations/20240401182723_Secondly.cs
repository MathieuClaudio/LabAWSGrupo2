using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class Secondly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Clubs_CurrentClubId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_CurrentClubId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CurrentClubId",
                table: "Players");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Players",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Clubs",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Players_IdClub",
                table: "Players",
                column: "IdClub");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Clubs_IdClub",
                table: "Players",
                column: "IdClub",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Clubs_IdClub",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_IdClub",
                table: "Players");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<int>(
                name: "CurrentClubId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Clubs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.CreateIndex(
                name: "IX_Players_CurrentClubId",
                table: "Players",
                column: "CurrentClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Clubs_CurrentClubId",
                table: "Players",
                column: "CurrentClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
