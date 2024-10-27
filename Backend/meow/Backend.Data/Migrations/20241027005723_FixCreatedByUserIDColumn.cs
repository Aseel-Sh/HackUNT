using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixCreatedByUserIDColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Meetings");

            migrationBuilder.RenameColumn(
                name: "CreatedbyUserID",
                table: "Meetings",
                newName: "CreatedByUserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedByUserID",
                table: "Meetings",
                newName: "CreatedbyUserID");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Meetings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
