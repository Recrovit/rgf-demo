using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RGF.Demo.Northwind.Data.Migrations.Oracle
{
    /// <inheritdoc />
    public partial class RGFDemoNorthwind_v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DROPDOWNCALLBACK",
                table: "CATEGORIES",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DROPDOWNENUM",
                table: "CATEGORIES",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DROPDOWNRECRODICT",
                table: "CATEGORIES",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DROPDOWNSTATIC",
                table: "CATEGORIES",
                type: "NUMBER(10)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DROPDOWNCALLBACK",
                table: "CATEGORIES");

            migrationBuilder.DropColumn(
                name: "DROPDOWNENUM",
                table: "CATEGORIES");

            migrationBuilder.DropColumn(
                name: "DROPDOWNRECRODICT",
                table: "CATEGORIES");

            migrationBuilder.DropColumn(
                name: "DROPDOWNSTATIC",
                table: "CATEGORIES");
        }
    }
}
