using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Newshore.EF.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ns");

            migrationBuilder.CreateTable(
                name: "SearchRegistry",
                schema: "ns",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchRegistry", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SearchRegistry_Destination",
                schema: "ns",
                table: "SearchRegistry",
                column: "Destination");

            migrationBuilder.CreateIndex(
                name: "IX_SearchRegistry_Origin",
                schema: "ns",
                table: "SearchRegistry",
                column: "Origin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchRegistry",
                schema: "ns");
        }
    }
}
