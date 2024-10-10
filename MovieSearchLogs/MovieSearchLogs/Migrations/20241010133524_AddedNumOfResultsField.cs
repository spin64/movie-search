using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieSearchLogs.Migrations
{
    public partial class AddedNumOfResultsField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImdbId",
                table: "Logs",
                newName: "numOfResults");

            migrationBuilder.AddColumn<string>(
                name: "movieTitle",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "movieTitle",
                table: "Logs");

            migrationBuilder.RenameColumn(
                name: "numOfResults",
                table: "Logs",
                newName: "ImdbId");
        }
    }
}
