using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieSearchLogs.Migrations
{
    public partial class ChangedLogSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "movieTitle",
                table: "Logs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "movieTitle",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
