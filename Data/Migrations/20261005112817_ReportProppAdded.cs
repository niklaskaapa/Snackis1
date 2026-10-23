using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Snackis1.Migrations
{
    /// <inheritdoc />
    public partial class ReportProppAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReportedPostAuthor",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReportedPostTitle",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportedPostAuthor",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ReportedPostTitle",
                table: "Reports");
        }
    }
}
