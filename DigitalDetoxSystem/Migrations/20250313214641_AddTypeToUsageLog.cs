using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalDetoxSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddTypeToUsageLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "UsageLogs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "UsageLogs");
        }
    }
}
