using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubEFLibrary.Migrations
{
    public partial class fixedTransfer2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "nieuwTeamStamNummer",
                table: "Transfers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "oudTeamStamNummer",
                table: "Transfers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_nieuwTeamStamNummer",
                table: "Transfers",
                column: "nieuwTeamStamNummer");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_oudTeamStamNummer",
                table: "Transfers",
                column: "oudTeamStamNummer");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Teams_nieuwTeamStamNummer",
                table: "Transfers",
                column: "nieuwTeamStamNummer",
                principalTable: "Teams",
                principalColumn: "StamNummer",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Teams_oudTeamStamNummer",
                table: "Transfers",
                column: "oudTeamStamNummer",
                principalTable: "Teams",
                principalColumn: "StamNummer",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Teams_nieuwTeamStamNummer",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Teams_oudTeamStamNummer",
                table: "Transfers");

            migrationBuilder.DropIndex(
                name: "IX_Transfers_nieuwTeamStamNummer",
                table: "Transfers");

            migrationBuilder.DropIndex(
                name: "IX_Transfers_oudTeamStamNummer",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "nieuwTeamStamNummer",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "oudTeamStamNummer",
                table: "Transfers");
        }
    }
}
