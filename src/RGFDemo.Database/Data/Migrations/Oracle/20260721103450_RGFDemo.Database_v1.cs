using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RGFDemo.Database.Data.Migrations.Oracle
{
    /// <inheritdoc />
    public partial class RGFDemoDatabase_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIES",
                columns: table => new
                {
                    CATEGORYID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CATEGORYNAME = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "NCLOB", nullable: true),
                    PICTURE = table.Column<byte[]>(type: "BLOB", nullable: true),
                    ROWVERSION = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIES", x => x.CATEGORYID);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMERDEMOGRAPHICS",
                columns: table => new
                {
                    CUSTOMERDEMOGRAPHICID = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    CUSTOMERDESC = table.Column<string>(type: "NCLOB", nullable: true),
                    ROWVERSION = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERDEMOGRAPHICS", x => x.CUSTOMERDEMOGRAPHICID);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMERS",
                columns: table => new
                {
                    CUSTOMERID = table.Column<string>(type: "NVARCHAR2(5)", maxLength: 5, nullable: false),
                    COMPANYNAME = table.Column<string>(type: "NVARCHAR2(40)", maxLength: 40, nullable: false),
                    CONTACTNAME = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: true),
                    CONTACTTITLE = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: true),
                    ADDRESS = table.Column<string>(type: "NVARCHAR2(60)", maxLength: 60, nullable: true),
                    CITY = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    REGION = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    POSTALCODE = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: true),
                    COUNTRY = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    PHONE = table.Column<string>(type: "NVARCHAR2(24)", maxLength: 24, nullable: true),
                    FAX = table.Column<string>(type: "NVARCHAR2(24)", maxLength: 24, nullable: true),
                    ROWVERSION = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERS", x => x.CUSTOMERID);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEES",
                columns: table => new
                {
                    EMPLOYEEID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    LASTNAME = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    FIRSTNAME = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    TITLE = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: true),
                    TITLEOFCOURTESY = table.Column<string>(type: "NVARCHAR2(25)", maxLength: 25, nullable: true),
                    BIRTHDATE = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    HIREDATE = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    ADDRESS = table.Column<string>(type: "NVARCHAR2(60)", maxLength: 60, nullable: true),
                    CITY = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    REGION = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    POSTALCODE = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: true),
                    COUNTRY = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    HOMEPHONE = table.Column<string>(type: "NVARCHAR2(24)", maxLength: 24, nullable: true),
                    EXTENSION = table.Column<string>(type: "NVARCHAR2(4)", maxLength: 4, nullable: true),
                    PHOTO = table.Column<byte[]>(type: "BLOB", nullable: true),
                    NOTES = table.Column<string>(type: "NCLOB", nullable: true),
                    PHOTOPATH = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    ROWVERSION = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValue: 0),
                    REPORTSTO = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEES", x => x.EMPLOYEEID);
                    table.ForeignKey(
                        name: "FK_EMPLOYEE_EMPLOYEE_REPORTSTO",
                        column: x => x.REPORTSTO,
                        principalTable: "EMPLOYEES",
                        principalColumn: "EMPLOYEEID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "REGION",
                columns: table => new
                {
                    REGIONID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    REGIONDESCRIPTION = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ROWVERSION = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGION", x => x.REGIONID);
                });

            migrationBuilder.CreateTable(
                name: "SHIPPERS",
                columns: table => new
                {
                    SHIPPERID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    COMPANYNAME = table.Column<string>(type: "NVARCHAR2(40)", maxLength: 40, nullable: false),
                    PHONE = table.Column<string>(type: "NVARCHAR2(24)", maxLength: 24, nullable: true),
                    ROWVERSION = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHIPPERS", x => x.SHIPPERID);
                });

            migrationBuilder.CreateTable(
                name: "SUPPLIERS",
                columns: table => new
                {
                    SUPPLIERID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    COMPANYNAME = table.Column<string>(type: "NVARCHAR2(40)", maxLength: 40, nullable: false),
                    CONTACTNAME = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: true),
                    CONTACTTITLE = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: true),
                    ADDRESS = table.Column<string>(type: "NVARCHAR2(60)", maxLength: 60, nullable: true),
                    CITY = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    REGION = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    POSTALCODE = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: true),
                    COUNTRY = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    PHONE = table.Column<string>(type: "NVARCHAR2(24)", maxLength: 24, nullable: true),
                    FAX = table.Column<string>(type: "NVARCHAR2(24)", maxLength: 24, nullable: true),
                    HOMEPAGE = table.Column<string>(type: "NCLOB", nullable: true),
                    ROWVERSION = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIERS", x => x.SUPPLIERID);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMERCUSTOMERDEMO",
                columns: table => new
                {
                    CUSTOMERCUSTOMERDEMOID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ROWVERSION = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValue: 0),
                    CUSTOMERID = table.Column<string>(type: "NVARCHAR2(5)", nullable: false),
                    CUSTOMERTYPEID = table.Column<string>(type: "NVARCHAR2(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERCUSTOMERDEMO", x => x.CUSTOMERCUSTOMERDEMOID);
                    table.ForeignKey(
                        name: "FK_CUSTOMERCUSTOMERDEMO_CUSTOMERDEMOGRAPHIC_CUSTOMERTYPEID",
                        column: x => x.CUSTOMERTYPEID,
                        principalTable: "CUSTOMERDEMOGRAPHICS",
                        principalColumn: "CUSTOMERDEMOGRAPHICID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CUSTOMERCUSTOMERDEMO_CUSTOMER_CUSTOMERID",
                        column: x => x.CUSTOMERID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "CUSTOMERID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TERRITORIES",
                columns: table => new
                {
                    TERRITORYID = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    TERRITORYDESCRIPTION = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ROWVERSION = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValue: 0),
                    REGIONID = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TERRITORIES", x => x.TERRITORYID);
                    table.ForeignKey(
                        name: "FK_TERRITORY_REGION_REGIONID",
                        column: x => x.REGIONID,
                        principalTable: "REGION",
                        principalColumn: "REGIONID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ORDERS",
                columns: table => new
                {
                    ORDERID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ORDERDATE = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    REQUIREDDATE = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    SHIPPEDDATE = table.Column<DateTime>(type: "TIMESTAMP", nullable: true),
                    FREIGHT = table.Column<decimal>(type: "NUMBER(18,2)", precision: 18, scale: 2, nullable: true, defaultValueSql: "0"),
                    SHIPNAME = table.Column<string>(type: "NVARCHAR2(40)", maxLength: 40, nullable: true),
                    SHIPADDRESS = table.Column<string>(type: "NVARCHAR2(60)", maxLength: 60, nullable: true),
                    SHIPCITY = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    SHIPREGION = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    SHIPPOSTALCODE = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: true),
                    SHIPCOUNTRY = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    ROWVERSION = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValue: 0),
                    CUSTOMERID = table.Column<string>(type: "NVARCHAR2(5)", nullable: false),
                    EMPLOYEEID = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    SHIPVIA = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS", x => x.ORDERID);
                    table.ForeignKey(
                        name: "FK_ORDER_CUSTOMER_CUSTOMERID",
                        column: x => x.CUSTOMERID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "CUSTOMERID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ORDER_EMPLOYEE_EMPLOYEEID",
                        column: x => x.EMPLOYEEID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "EMPLOYEEID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ORDER_SHIPPER_SHIPVIA",
                        column: x => x.SHIPVIA,
                        principalTable: "SHIPPERS",
                        principalColumn: "SHIPPERID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    PRODUCTID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PRODUCTNAME = table.Column<string>(type: "NVARCHAR2(40)", maxLength: 40, nullable: false),
                    QUANTITYPERUNIT = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: true),
                    UNITPRICE = table.Column<decimal>(type: "NUMBER(18,4)", precision: 18, scale: 4, nullable: true, defaultValueSql: "0"),
                    UNITSINSTOCK = table.Column<short>(type: "NUMBER(5)", nullable: true, defaultValueSql: "0"),
                    UNITSONORDER = table.Column<short>(type: "NUMBER(5)", nullable: true, defaultValueSql: "0"),
                    REORDERLEVEL = table.Column<short>(type: "NUMBER(5)", nullable: true, defaultValueSql: "0"),
                    DISCONTINUED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ROWVERSION = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValue: 0),
                    CATEGORYID = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    SUPPLIERID = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.PRODUCTID);
                    table.ForeignKey(
                        name: "FK_PRODUCT_CATEGORY_CATEGORYID",
                        column: x => x.CATEGORYID,
                        principalTable: "CATEGORIES",
                        principalColumn: "CATEGORYID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PRODUCT_SUPPLIER_SUPPLIERID",
                        column: x => x.SUPPLIERID,
                        principalTable: "SUPPLIERS",
                        principalColumn: "SUPPLIERID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEETERRITORIES",
                columns: table => new
                {
                    EMPLOYEETERRITORYID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ROWVERSION = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValue: 0),
                    EMPLOYEEID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TERRITORYID = table.Column<string>(type: "NVARCHAR2(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEETERRITORIES", x => x.EMPLOYEETERRITORYID);
                    table.ForeignKey(
                        name: "FK_EMPLOYEETERRITORY_EMPLOYEE_EMPLOYEEID",
                        column: x => x.EMPLOYEEID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "EMPLOYEEID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EMPLOYEETERRITORY_TERRITORY_TERRITORYID",
                        column: x => x.TERRITORYID,
                        principalTable: "TERRITORIES",
                        principalColumn: "TERRITORYID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ORDERDETAILS",
                columns: table => new
                {
                    ORDERDETAILID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UNITPRICE = table.Column<decimal>(type: "NUMBER(18,4)", precision: 18, scale: 4, nullable: false),
                    QUANTITY = table.Column<short>(type: "NUMBER(5)", nullable: false),
                    DISCOUNT = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    ROWVERSION = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValue: 0),
                    ORDERID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PRODUCTID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERDETAILS", x => x.ORDERDETAILID);
                    table.ForeignKey(
                        name: "FK_ORDERDETAIL_ORDER_ORDERID",
                        column: x => x.ORDERID,
                        principalTable: "ORDERS",
                        principalColumn: "ORDERID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ORDERDETAIL_PRODUCT_PRODUCTID",
                        column: x => x.PRODUCTID,
                        principalTable: "PRODUCTS",
                        principalColumn: "PRODUCTID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SCDEMO_NORTHWIND_CATEGORY_CATEGORYNAME",
                table: "CATEGORIES",
                column: "CATEGORYNAME");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERCUSTOMERDEMO_CUSTOMERID",
                table: "CUSTOMERCUSTOMERDEMO",
                column: "CUSTOMERID");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERCUSTOMERDEMO_CUSTOMERTYPEID",
                table: "CUSTOMERCUSTOMERDEMO",
                column: "CUSTOMERTYPEID");

            migrationBuilder.CreateIndex(
                name: "IX_SCDEMO_NORTHWIND_CUSTOMER_CITY",
                table: "CUSTOMERS",
                column: "CITY");

            migrationBuilder.CreateIndex(
                name: "IX_SCDEMO_NORTHWIND_CUSTOMER_COMPANYNAME",
                table: "CUSTOMERS",
                column: "COMPANYNAME");

            migrationBuilder.CreateIndex(
                name: "IX_SCDEMO_NORTHWIND_CUSTOMER_POSTALCODE",
                table: "CUSTOMERS",
                column: "POSTALCODE");

            migrationBuilder.CreateIndex(
                name: "IX_SCDEMO_NORTHWIND_CUSTOMER_REGION",
                table: "CUSTOMERS",
                column: "REGION");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_REPORTSTO",
                table: "EMPLOYEES",
                column: "REPORTSTO");

            migrationBuilder.CreateIndex(
                name: "IX_SCDEMO_NORTHWIND_EMPLOYEE_LASTNAME",
                table: "EMPLOYEES",
                column: "LASTNAME");

            migrationBuilder.CreateIndex(
                name: "IX_SCDEMO_NORTHWIND_EMPLOYEE_POSTALCODE",
                table: "EMPLOYEES",
                column: "POSTALCODE");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEETERRITORIES_EMPLOYEEID",
                table: "EMPLOYEETERRITORIES",
                column: "EMPLOYEEID");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEETERRITORIES_TERRITORYID",
                table: "EMPLOYEETERRITORIES",
                column: "TERRITORYID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERDETAILS_ORDERID",
                table: "ORDERDETAILS",
                column: "ORDERID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERDETAILS_PRODUCTID",
                table: "ORDERDETAILS",
                column: "PRODUCTID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_CUSTOMERID",
                table: "ORDERS",
                column: "CUSTOMERID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_EMPLOYEEID",
                table: "ORDERS",
                column: "EMPLOYEEID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_SHIPVIA",
                table: "ORDERS",
                column: "SHIPVIA");

            migrationBuilder.CreateIndex(
                name: "IX_SCDEMO_NORTHWIND_ORDER_ORDERDATE",
                table: "ORDERS",
                column: "ORDERDATE");

            migrationBuilder.CreateIndex(
                name: "IX_SCDEMO_NORTHWIND_ORDER_SHIPPEDDATE",
                table: "ORDERS",
                column: "SHIPPEDDATE");

            migrationBuilder.CreateIndex(
                name: "IX_SCDEMO_NORTHWIND_ORDER_SHIPPOSTALCODE",
                table: "ORDERS",
                column: "SHIPPOSTALCODE");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_CATEGORYID",
                table: "PRODUCTS",
                column: "CATEGORYID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_SUPPLIERID",
                table: "PRODUCTS",
                column: "SUPPLIERID");

            migrationBuilder.CreateIndex(
                name: "IX_SCDEMO_NORTHWIND_PRODUCT_PRODUCTNAME",
                table: "PRODUCTS",
                column: "PRODUCTNAME");

            migrationBuilder.CreateIndex(
                name: "IX_SCDEMO_NORTHWIND_SHIPPER_COMPANYNAME",
                table: "SHIPPERS",
                column: "COMPANYNAME");

            migrationBuilder.CreateIndex(
                name: "IX_SCDEMO_NORTHWIND_SUPPLIER_COMPANYNAME",
                table: "SUPPLIERS",
                column: "COMPANYNAME");

            migrationBuilder.CreateIndex(
                name: "IX_SCDEMO_NORTHWIND_SUPPLIER_POSTALCODE",
                table: "SUPPLIERS",
                column: "POSTALCODE");

            migrationBuilder.CreateIndex(
                name: "IX_TERRITORIES_REGIONID",
                table: "TERRITORIES",
                column: "REGIONID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CUSTOMERCUSTOMERDEMO");

            migrationBuilder.DropTable(
                name: "EMPLOYEETERRITORIES");

            migrationBuilder.DropTable(
                name: "ORDERDETAILS");

            migrationBuilder.DropTable(
                name: "CUSTOMERDEMOGRAPHICS");

            migrationBuilder.DropTable(
                name: "TERRITORIES");

            migrationBuilder.DropTable(
                name: "ORDERS");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "REGION");

            migrationBuilder.DropTable(
                name: "CUSTOMERS");

            migrationBuilder.DropTable(
                name: "EMPLOYEES");

            migrationBuilder.DropTable(
                name: "SHIPPERS");

            migrationBuilder.DropTable(
                name: "CATEGORIES");

            migrationBuilder.DropTable(
                name: "SUPPLIERS");
        }
    }
}
