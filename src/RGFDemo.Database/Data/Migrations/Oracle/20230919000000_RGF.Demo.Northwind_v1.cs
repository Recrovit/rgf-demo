using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RGF.Demo.Northwind.Data.Migrations.Oracle
{
    public partial class RGFNorthwind_v1 : Migration
    {
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
                    ROWVERSION = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIES", x => x.CATEGORYID);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMERDEMOGRAPHICS",
                columns: table => new
                {
                    CUSTOMERTYPEID = table.Column<string>(type: "NCHAR(10)", nullable: false),
                    CUSTOMERDESC = table.Column<string>(type: "NCLOB", nullable: true),
                    ROWVERSION = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERDEMOGRAPHICS", x => x.CUSTOMERTYPEID);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMERS",
                columns: table => new
                {
                    CUSTOMERID = table.Column<string>(type: "NCHAR(5)", nullable: false),
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
                    ROWVERSION = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValueSql: "(0)")
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
                    BIRTHDATE = table.Column<DateTime>(type: "timestamp", nullable: true),
                    HIREDATE = table.Column<DateTime>(type: "timestamp", nullable: true),
                    ADDRESS = table.Column<string>(type: "NVARCHAR2(60)", maxLength: 60, nullable: true),
                    CITY = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    REGION = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    POSTALCODE = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: true),
                    COUNTRY = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    HOMEPHONE = table.Column<string>(type: "NVARCHAR2(24)", maxLength: 24, nullable: true),
                    EXTENSION = table.Column<string>(type: "NVARCHAR2(4)", maxLength: 4, nullable: true),
                    PHOTO = table.Column<byte[]>(type: "BLOB", nullable: true),
                    NOTES = table.Column<string>(type: "NCLOB", nullable: true),
                    REPORTSTO = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    PHOTOPATH = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    ROWVERSION = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEES", x => x.EMPLOYEEID);
                    table.ForeignKey(
                        name: "FK_EMPLOYEES_EMPLOYEES",
                        column: x => x.REPORTSTO,
                        principalTable: "EMPLOYEES",
                        principalColumn: "EMPLOYEEID");
                });

            migrationBuilder.CreateTable(
                name: "REGION",
                columns: table => new
                {
                    REGIONID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    REGIONDESCRIPTION = table.Column<string>(type: "NCHAR(50)", nullable: false),
                    ROWVERSION = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValueSql: "(0)")
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
                    ROWVERSION = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValueSql: "(0)")
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
                    ROWVERSION = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIERS", x => x.SUPPLIERID);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMERCUSTOMERDEMO",
                columns: table => new
                {
                    CUSTOMERID = table.Column<string>(type: "NCHAR(5)", nullable: false),
                    CUSTOMERTYPEID = table.Column<string>(type: "NCHAR(10)", nullable: false),
                    ROWVERSION = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERCUSTOMERDEMO", x => new { x.CUSTOMERID, x.CUSTOMERTYPEID });
                    table.ForeignKey(
                        name: "FK_CUSTOMERCUSTOMERDEMO",
                        column: x => x.CUSTOMERTYPEID,
                        principalTable: "CUSTOMERDEMOGRAPHICS",
                        principalColumn: "CUSTOMERTYPEID");
                    table.ForeignKey(
                        name: "FK_CUSTOMERCUSTOMERDEMO_CUST",
                        column: x => x.CUSTOMERID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "CUSTOMERID");
                });

            migrationBuilder.CreateTable(
                name: "TERRITORIES",
                columns: table => new
                {
                    TERRITORYID = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    TERRITORYDESCRIPTION = table.Column<string>(type: "NCHAR(50)", nullable: false),
                    REGIONID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ROWVERSION = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TERRITORIES", x => x.TERRITORYID);
                    table.ForeignKey(
                        name: "FK_TERRITORIES_REGION",
                        column: x => x.REGIONID,
                        principalTable: "REGION",
                        principalColumn: "REGIONID");
                });

            migrationBuilder.CreateTable(
                name: "ORDERS",
                columns: table => new
                {
                    ORDERID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CUSTOMERID = table.Column<string>(type: "NCHAR(5)", nullable: true),
                    EMPLOYEEID = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ORDERDATE = table.Column<DateTime>(type: "timestamp", nullable: true),
                    REQUIREDDATE = table.Column<DateTime>(type: "timestamp", nullable: true),
                    SHIPPEDDATE = table.Column<DateTime>(type: "timestamp", nullable: true),
                    SHIPVIA = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    FREIGHT = table.Column<decimal>(type: "numeric(19,4)", nullable: true, defaultValueSql: "(0)"),
                    SHIPNAME = table.Column<string>(type: "NVARCHAR2(40)", maxLength: 40, nullable: true),
                    SHIPADDRESS = table.Column<string>(type: "NVARCHAR2(60)", maxLength: 60, nullable: true),
                    SHIPCITY = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    SHIPREGION = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    SHIPPOSTALCODE = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: true),
                    SHIPCOUNTRY = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: true),
                    ROWVERSION = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS", x => x.ORDERID);
                    table.ForeignKey(
                        name: "FK_ORDERS_CUSTOMERS",
                        column: x => x.CUSTOMERID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "CUSTOMERID");
                    table.ForeignKey(
                        name: "FK_ORDERS_EMPLOYEES",
                        column: x => x.EMPLOYEEID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "EMPLOYEEID");
                    table.ForeignKey(
                        name: "FK_ORDERS_SHIPPERS",
                        column: x => x.SHIPVIA,
                        principalTable: "SHIPPERS",
                        principalColumn: "SHIPPERID");
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    PRODUCTID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PRODUCTNAME = table.Column<string>(type: "NVARCHAR2(40)", maxLength: 40, nullable: false),
                    SUPPLIERID = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    CATEGORYID = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    QUANTITYPERUNIT = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: true),
                    UNITPRICE = table.Column<decimal>(type: "numeric(19,4)", nullable: true, defaultValueSql: "(0)"),
                    UNITSINSTOCK = table.Column<short>(type: "NUMBER(5)", nullable: true, defaultValueSql: "(0)"),
                    UNITSONORDER = table.Column<short>(type: "NUMBER(5)", nullable: true, defaultValueSql: "(0)"),
                    REORDERLEVEL = table.Column<short>(type: "NUMBER(5)", nullable: true, defaultValueSql: "(0)"),
                    DISCONTINUED = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ROWVERSION = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.PRODUCTID);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_CATEGORIES",
                        column: x => x.CATEGORYID,
                        principalTable: "CATEGORIES",
                        principalColumn: "CATEGORYID");
                    table.ForeignKey(
                        name: "FK_PRODUCTS_SUPPLIERS",
                        column: x => x.SUPPLIERID,
                        principalTable: "SUPPLIERS",
                        principalColumn: "SUPPLIERID");
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEETERRITORIES",
                columns: table => new
                {
                    EMPLOYEEID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TERRITORYID = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    ROWVERSION = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEETERRITORIES", x => new { x.EMPLOYEEID, x.TERRITORYID });
                    table.ForeignKey(
                        name: "FK_EMPLOYEETERRITORIES_EMP",
                        column: x => x.EMPLOYEEID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "EMPLOYEEID");
                    table.ForeignKey(
                        name: "FK_EMPLOYEETERRITORIES_TERR",
                        column: x => x.TERRITORYID,
                        principalTable: "TERRITORIES",
                        principalColumn: "TERRITORYID");
                });

            migrationBuilder.CreateTable(
                name: "ORDERDETAILS",
                columns: table => new
                {
                    ORDERID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PRODUCTID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UNITPRICE = table.Column<decimal>(type: "numeric(19,4)", nullable: false, defaultValueSql: "(0)"),
                    QUANTITY = table.Column<short>(type: "NUMBER(5)", nullable: false, defaultValue: (short)1),
                    DISCOUNT = table.Column<float>(type: "BINARY_FLOAT", nullable: false, defaultValueSql: "(0)"),
                    ROWVERSION = table.Column<int>(type: "NUMBER(10)", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERDETAILS", x => new { x.ORDERID, x.PRODUCTID });
                    table.ForeignKey(
                        name: "FK_ORDER_DETAILS_ORDERS",
                        column: x => x.ORDERID,
                        principalTable: "ORDERS",
                        principalColumn: "ORDERID");
                    table.ForeignKey(
                        name: "FK_ORDER_DETAILS_PRODUCTS",
                        column: x => x.PRODUCTID,
                        principalTable: "PRODUCTS",
                        principalColumn: "PRODUCTID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORIES_CATEGORYNAME",
                table: "CATEGORIES",
                column: "CATEGORYNAME");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERCUSTOMERDEMO_CUSTOMERTYPEID",
                table: "CUSTOMERCUSTOMERDEMO",
                column: "CUSTOMERTYPEID");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERS_CITY",
                table: "CUSTOMERS",
                column: "CITY");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERS_COMPANYNAME",
                table: "CUSTOMERS",
                column: "COMPANYNAME");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERS_POSTALCODE",
                table: "CUSTOMERS",
                column: "POSTALCODE");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMERS_REGION",
                table: "CUSTOMERS",
                column: "REGION");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_LASTNAME",
                table: "EMPLOYEES",
                column: "LASTNAME");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_POSTALCODE",
                table: "EMPLOYEES",
                column: "POSTALCODE");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_REPORTSTO",
                table: "EMPLOYEES",
                column: "REPORTSTO");

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
                name: "IX_ORDERS_ORDERDATE",
                table: "ORDERS",
                column: "ORDERDATE");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_SHIPPEDDATE",
                table: "ORDERS",
                column: "SHIPPEDDATE");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_SHIPPOSTALCODE",
                table: "ORDERS",
                column: "SHIPPOSTALCODE");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_SHIPVIA",
                table: "ORDERS",
                column: "SHIPVIA");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_CATEGORYID",
                table: "PRODUCTS",
                column: "CATEGORYID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_PRODUCTNAME",
                table: "PRODUCTS",
                column: "PRODUCTNAME");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_SUPPLIERID",
                table: "PRODUCTS",
                column: "SUPPLIERID");

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLIERS_COMPANYNAME",
                table: "SUPPLIERS",
                column: "COMPANYNAME");

            migrationBuilder.CreateIndex(
                name: "IX_SUPPLIERS_POSTALCODE",
                table: "SUPPLIERS",
                column: "POSTALCODE");

            migrationBuilder.CreateIndex(
                name: "IX_TERRITORIES_REGIONID",
                table: "TERRITORIES",
                column: "REGIONID");
        }

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
