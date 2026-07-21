using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RGF.Demo.Northwind.Data.Migrations.SQLServer
{
    /// <inheritdoc />
    public partial class RGFDemoNorthwind_v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DropdownCallback",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DropdownEnum",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DropdownRecroDict",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DropdownStatic",
                table: "Categories",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DropdownCallback",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DropdownEnum",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DropdownRecroDict",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DropdownStatic",
                table: "Categories");
        }
    }
}
