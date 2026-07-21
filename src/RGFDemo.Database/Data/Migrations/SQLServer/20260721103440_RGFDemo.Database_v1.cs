using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RGFDemo.Database.Data.Migrations.SQLServer
{
    /// <inheritdoc />
    public partial class RGFDemoDatabase_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    rowversion = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDemographics",
                columns: table => new
                {
                    CustomerDemographicId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CustomerDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rowversion = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDemographics", x => x.CustomerDemographicId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ContactTitle = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    City = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    rowversion = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    TitleOfCourtesy = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    City = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    HomePhone = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    rowversion = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ReportsTo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_Employee_ReportsTo",
                        column: x => x.ReportsTo,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    RegionDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    rowversion = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.RegionId);
                });

            migrationBuilder.CreateTable(
                name: "Shippers",
                columns: table => new
                {
                    ShipperId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    rowversion = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippers", x => x.ShipperId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ContactTitle = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    City = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Region = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    HomePage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rowversion = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCustomerDemo",
                columns: table => new
                {
                    CustomerCustomerDemoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rowversion = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CustomerId = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    CustomerTypeId = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCustomerDemo", x => x.CustomerCustomerDemoId);
                    table.ForeignKey(
                        name: "FK_CustomerCustomerDemo_CustomerDemographic_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "CustomerDemographics",
                        principalColumn: "CustomerDemographicId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerCustomerDemo_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Territories",
                columns: table => new
                {
                    TerritoryId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TerritoryDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    rowversion = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    RegionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Territories", x => x.TerritoryId);
                    table.ForeignKey(
                        name: "FK_Territory_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShippedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Freight = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true, defaultValueSql: "0"),
                    ShipName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ShipAddress = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    ShipCity = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ShipRegion = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ShipPostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ShipCountry = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    rowversion = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CustomerId = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    ShipVia = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Order_Shipper_ShipVia",
                        column: x => x.ShipVia,
                        principalTable: "Shippers",
                        principalColumn: "ShipperId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    QuantityPerUnit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true, defaultValueSql: "0"),
                    UnitsInStock = table.Column<short>(type: "smallint", nullable: true, defaultValueSql: "0"),
                    UnitsOnOrder = table.Column<short>(type: "smallint", nullable: true, defaultValueSql: "0"),
                    ReorderLevel = table.Column<short>(type: "smallint", nullable: true, defaultValueSql: "0"),
                    Discontinued = table.Column<bool>(type: "bit", nullable: false),
                    rowversion = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Product_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTerritories",
                columns: table => new
                {
                    EmployeeTerritoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rowversion = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TerritoryId = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTerritories", x => x.EmployeeTerritoryId);
                    table.ForeignKey(
                        name: "FK_EmployeeTerritory_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeTerritory_Territory_TerritoryId",
                        column: x => x.TerritoryId,
                        principalTable: "Territories",
                        principalColumn: "TerritoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Quantity = table.Column<short>(type: "smallint", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    rowversion = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScDemo_Northwind_Category_CategoryName",
                table: "Categories",
                column: "CategoryName");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCustomerDemo_CustomerId",
                table: "CustomerCustomerDemo",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCustomerDemo_CustomerTypeId",
                table: "CustomerCustomerDemo",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ScDemo_Northwind_Customer_City",
                table: "Customers",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "IX_ScDemo_Northwind_Customer_CompanyName",
                table: "Customers",
                column: "CompanyName");

            migrationBuilder.CreateIndex(
                name: "IX_ScDemo_Northwind_Customer_PostalCode",
                table: "Customers",
                column: "PostalCode");

            migrationBuilder.CreateIndex(
                name: "IX_ScDemo_Northwind_Customer_Region",
                table: "Customers",
                column: "Region");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReportsTo",
                table: "Employees",
                column: "ReportsTo");

            migrationBuilder.CreateIndex(
                name: "IX_ScDemo_Northwind_Employee_LastName",
                table: "Employees",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_ScDemo_Northwind_Employee_PostalCode",
                table: "Employees",
                column: "PostalCode");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTerritories_EmployeeId",
                table: "EmployeeTerritories",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTerritories_TerritoryId",
                table: "EmployeeTerritories",
                column: "TerritoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeId",
                table: "Orders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipVia",
                table: "Orders",
                column: "ShipVia");

            migrationBuilder.CreateIndex(
                name: "IX_ScDemo_Northwind_Order_OrderDate",
                table: "Orders",
                column: "OrderDate");

            migrationBuilder.CreateIndex(
                name: "IX_ScDemo_Northwind_Order_ShippedDate",
                table: "Orders",
                column: "ShippedDate");

            migrationBuilder.CreateIndex(
                name: "IX_ScDemo_Northwind_Order_ShipPostalCode",
                table: "Orders",
                column: "ShipPostalCode");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ScDemo_Northwind_Product_ProductName",
                table: "Products",
                column: "ProductName");

            migrationBuilder.CreateIndex(
                name: "IX_ScDemo_Northwind_Shipper_CompanyName",
                table: "Shippers",
                column: "CompanyName");

            migrationBuilder.CreateIndex(
                name: "IX_ScDemo_Northwind_Supplier_CompanyName",
                table: "Suppliers",
                column: "CompanyName");

            migrationBuilder.CreateIndex(
                name: "IX_ScDemo_Northwind_Supplier_PostalCode",
                table: "Suppliers",
                column: "PostalCode");

            migrationBuilder.CreateIndex(
                name: "IX_Territories_RegionId",
                table: "Territories",
                column: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerCustomerDemo");

            migrationBuilder.DropTable(
                name: "EmployeeTerritories");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "CustomerDemographics");

            migrationBuilder.DropTable(
                name: "Territories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Shippers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
