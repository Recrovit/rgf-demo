using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RGF.Demo.Northwind.Data.Migrations.PostgreSQL
{
    /// <inheritdoc />
    public partial class RGFDemoNorthwind_v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "dropdowncallback",
                table: "categories",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "dropdownenum",
                table: "categories",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "dropdownrecrodict",
                table: "categories",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "dropdownstatic",
                table: "categories",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dropdowncallback",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "dropdownenum",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "dropdownrecrodict",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "dropdownstatic",
                table: "categories");
        }
    }
}
