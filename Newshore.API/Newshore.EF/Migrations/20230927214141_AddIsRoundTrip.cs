using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Newshore.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddIsRoundTrip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRoundTrip",
                schema: "ns",
                table: "SearchRegistry",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRoundTrip",
                schema: "ns",
                table: "SearchRegistry");
        }
    }
}
