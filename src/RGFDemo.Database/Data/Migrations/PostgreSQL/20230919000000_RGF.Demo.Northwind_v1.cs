using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RGF.Demo.Northwind.Data.Migrations.PostgreSQL
{
    public partial class RGFNorthwind_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "public",
                columns: table => new
                {
                    categoryid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    categoryname = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    picture = table.Column<byte[]>(type: "bytea", nullable: true),
                    rowversion = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.categoryid);
                });

            migrationBuilder.CreateTable(
                name: "customerdemographics",
                schema: "public",
                columns: table => new
                {
                    customertypeid = table.Column<string>(type: "character(10)", nullable: false),
                    customerdesc = table.Column<string>(type: "text", nullable: true),
                    rowversion = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customerdemographics", x => x.customertypeid);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                schema: "public",
                columns: table => new
                {
                    customerid = table.Column<string>(type: "character(5)", nullable: false),
                    companyname = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    contactname = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    contacttitle = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    address = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    city = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    region = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    postalcode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    country = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    phone = table.Column<string>(type: "character varying(24)", maxLength: 24, nullable: true),
                    fax = table.Column<string>(type: "character varying(24)", maxLength: 24, nullable: true),
                    rowversion = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customers", x => x.customerid);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                schema: "public",
                columns: table => new
                {
                    employeeid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lastname = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    firstname = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    title = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    titleofcourtesy = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    birthdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    hiredate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    address = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    city = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    region = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    postalcode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    country = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    homephone = table.Column<string>(type: "character varying(24)", maxLength: 24, nullable: true),
                    extension = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    photo = table.Column<byte[]>(type: "bytea", nullable: true),
                    notes = table.Column<string>(type: "text", nullable: true),
                    reportsto = table.Column<int>(type: "integer", nullable: true),
                    photopath = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    rowversion = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employees", x => x.employeeid);
                    table.ForeignKey(
                        name: "fk_employees_employees",
                        column: x => x.reportsto,
                        principalSchema: "public",
                        principalTable: "employees",
                        principalColumn: "employeeid");
                });

            migrationBuilder.CreateTable(
                name: "region",
                schema: "public",
                columns: table => new
                {
                    regionid = table.Column<int>(type: "integer", nullable: false),
                    regiondescription = table.Column<string>(type: "character(50)", nullable: false),
                    rowversion = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_region", x => x.regionid);
                });

            migrationBuilder.CreateTable(
                name: "shippers",
                schema: "public",
                columns: table => new
                {
                    shipperid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    companyname = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    phone = table.Column<string>(type: "character varying(24)", maxLength: 24, nullable: true),
                    rowversion = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_shippers", x => x.shipperid);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                schema: "public",
                columns: table => new
                {
                    supplierid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    companyname = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    contactname = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    contacttitle = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    address = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    city = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    region = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    postalcode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    country = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    phone = table.Column<string>(type: "character varying(24)", maxLength: 24, nullable: true),
                    fax = table.Column<string>(type: "character varying(24)", maxLength: 24, nullable: true),
                    homepage = table.Column<string>(type: "text", nullable: true),
                    rowversion = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_suppliers", x => x.supplierid);
                });

            migrationBuilder.CreateTable(
                name: "customercustomerdemo",
                schema: "public",
                columns: table => new
                {
                    customerid = table.Column<string>(type: "character(5)", nullable: false),
                    customertypeid = table.Column<string>(type: "character(10)", nullable: false),
                    rowversion = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customercustomerdemo", x => new { x.customerid, x.customertypeid });
                    table.ForeignKey(
                        name: "fk_customercustomerdemo",
                        column: x => x.customertypeid,
                        principalSchema: "public",
                        principalTable: "customerdemographics",
                        principalColumn: "customertypeid");
                    table.ForeignKey(
                        name: "fk_customercustomerdemo_customers",
                        column: x => x.customerid,
                        principalSchema: "public",
                        principalTable: "customers",
                        principalColumn: "customerid");
                });

            migrationBuilder.CreateTable(
                name: "territories",
                schema: "public",
                columns: table => new
                {
                    territoryid = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    territorydescription = table.Column<string>(type: "character(50)", nullable: false),
                    regionid = table.Column<int>(type: "integer", nullable: false),
                    rowversion = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_territories", x => x.territoryid);
                    table.ForeignKey(
                        name: "fk_territories_region",
                        column: x => x.regionid,
                        principalSchema: "public",
                        principalTable: "region",
                        principalColumn: "regionid");
                });

            migrationBuilder.CreateTable(
                name: "orders",
                schema: "public",
                columns: table => new
                {
                    orderid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customerid = table.Column<string>(type: "character(5)", nullable: true),
                    employeeid = table.Column<int>(type: "integer", nullable: true),
                    orderdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    requireddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    shippeddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    shipvia = table.Column<int>(type: "integer", nullable: true),
                    freight = table.Column<decimal>(type: "numeric(19,4)", nullable: true, defaultValueSql: "(0)"),
                    shipname = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    shipaddress = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    shipcity = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    shipregion = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    shippostalcode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    shipcountry = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    rowversion = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.orderid);
                    table.ForeignKey(
                        name: "fk_orders_customers",
                        column: x => x.customerid,
                        principalSchema: "public",
                        principalTable: "customers",
                        principalColumn: "customerid");
                    table.ForeignKey(
                        name: "fk_orders_employees",
                        column: x => x.employeeid,
                        principalSchema: "public",
                        principalTable: "employees",
                        principalColumn: "employeeid");
                    table.ForeignKey(
                        name: "fk_orders_shippers",
                        column: x => x.shipvia,
                        principalSchema: "public",
                        principalTable: "shippers",
                        principalColumn: "shipperid");
                });

            migrationBuilder.CreateTable(
                name: "products",
                schema: "public",
                columns: table => new
                {
                    productid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    productname = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    supplierid = table.Column<int>(type: "integer", nullable: true),
                    categoryid = table.Column<int>(type: "integer", nullable: true),
                    quantityperunit = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    unitprice = table.Column<decimal>(type: "numeric(19,4)", nullable: true, defaultValueSql: "(0)"),
                    unitsinstock = table.Column<short>(type: "smallint", nullable: true, defaultValueSql: "(0)"),
                    unitsonorder = table.Column<short>(type: "smallint", nullable: true, defaultValueSql: "(0)"),
                    reorderlevel = table.Column<short>(type: "smallint", nullable: true, defaultValueSql: "(0)"),
                    discontinued = table.Column<bool>(type: "boolean", nullable: false),
                    rowversion = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.productid);
                    table.ForeignKey(
                        name: "fk_products_categories",
                        column: x => x.categoryid,
                        principalSchema: "public",
                        principalTable: "categories",
                        principalColumn: "categoryid");
                    table.ForeignKey(
                        name: "fk_products_suppliers",
                        column: x => x.supplierid,
                        principalSchema: "public",
                        principalTable: "suppliers",
                        principalColumn: "supplierid");
                });

            migrationBuilder.CreateTable(
                name: "employeeterritories",
                schema: "public",
                columns: table => new
                {
                    employeeid = table.Column<int>(type: "integer", nullable: false),
                    territoryid = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    rowversion = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employeeterritories", x => new { x.employeeid, x.territoryid });
                    table.ForeignKey(
                        name: "fk_employeeterritories_employees",
                        column: x => x.employeeid,
                        principalSchema: "public",
                        principalTable: "employees",
                        principalColumn: "employeeid");
                    table.ForeignKey(
                        name: "fk_employeeterritories_territories",
                        column: x => x.territoryid,
                        principalSchema: "public",
                        principalTable: "territories",
                        principalColumn: "territoryid");
                });

            migrationBuilder.CreateTable(
                name: "orderdetails",
                schema: "public",
                columns: table => new
                {
                    orderid = table.Column<int>(type: "integer", nullable: false),
                    productid = table.Column<int>(type: "integer", nullable: false),
                    unitprice = table.Column<decimal>(type: "numeric(19,4)", nullable: false, defaultValueSql: "(0)"),
                    quantity = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "((1))"),
                    discount = table.Column<float>(type: "real", nullable: false, defaultValueSql: "(0)"),
                    rowversion = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orderdetails", x => new { x.orderid, x.productid });
                    table.ForeignKey(
                        name: "fk_order_details_orders",
                        column: x => x.orderid,
                        principalSchema: "public",
                        principalTable: "orders",
                        principalColumn: "orderid");
                    table.ForeignKey(
                        name: "fk_order_details_products",
                        column: x => x.productid,
                        principalSchema: "public",
                        principalTable: "products",
                        principalColumn: "productid");
                });

            migrationBuilder.CreateIndex(
                name: "ix_categories_categoryname",
                schema: "public",
                table: "categories",
                column: "categoryname");

            migrationBuilder.CreateIndex(
                name: "ix_customercustomerdemo_customertypeid",
                schema: "public",
                table: "customercustomerdemo",
                column: "customertypeid");

            migrationBuilder.CreateIndex(
                name: "ix_customers_city",
                schema: "public",
                table: "customers",
                column: "city");

            migrationBuilder.CreateIndex(
                name: "ix_customers_companyname",
                schema: "public",
                table: "customers",
                column: "companyname");

            migrationBuilder.CreateIndex(
                name: "ix_customers_postalcode",
                schema: "public",
                table: "customers",
                column: "postalcode");

            migrationBuilder.CreateIndex(
                name: "ix_customers_region",
                schema: "public",
                table: "customers",
                column: "region");

            migrationBuilder.CreateIndex(
                name: "ix_employees_lastname",
                schema: "public",
                table: "employees",
                column: "lastname");

            migrationBuilder.CreateIndex(
                name: "ix_employees_postalcode",
                schema: "public",
                table: "employees",
                column: "postalcode");

            migrationBuilder.CreateIndex(
                name: "ix_employees_reportsto",
                schema: "public",
                table: "employees",
                column: "reportsto");

            migrationBuilder.CreateIndex(
                name: "ix_employeeterritories_territoryid",
                schema: "public",
                table: "employeeterritories",
                column: "territoryid");

            migrationBuilder.CreateIndex(
                name: "ix_ordersorder_details",
                schema: "public",
                table: "orderdetails",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "ix_ordersorder_productsorder_details",
                schema: "public",
                table: "orderdetails",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_orders_customersorders",
                schema: "public",
                table: "orders",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "ix_orders_employeesorders",
                schema: "public",
                table: "orders",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "ix_orders_orderdate",
                schema: "public",
                table: "orders",
                column: "orderdate");

            migrationBuilder.CreateIndex(
                name: "ix_orders_shippeddate",
                schema: "public",
                table: "orders",
                column: "shippeddate");

            migrationBuilder.CreateIndex(
                name: "ix_orders_shippersorders",
                schema: "public",
                table: "orders",
                column: "shipvia");

            migrationBuilder.CreateIndex(
                name: "ix_orders_shippostalcode",
                schema: "public",
                table: "orders",
                column: "shippostalcode");

            migrationBuilder.CreateIndex(
                name: "ix_products_categoryid",
                schema: "public",
                table: "products",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "ix_products_productname",
                schema: "public",
                table: "products",
                column: "productname");

            migrationBuilder.CreateIndex(
                name: "ix_products_suppliersproducts",
                schema: "public",
                table: "products",
                column: "supplierid");

            migrationBuilder.CreateIndex(
                name: "ix_suppliers_companyname",
                schema: "public",
                table: "suppliers",
                column: "companyname");

            migrationBuilder.CreateIndex(
                name: "ix_suppliers_postalcode",
                schema: "public",
                table: "suppliers",
                column: "postalcode");

            migrationBuilder.CreateIndex(
                name: "ix_territories_regionid",
                schema: "public",
                table: "territories",
                column: "regionid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customercustomerdemo",
                schema: "public");

            migrationBuilder.DropTable(
                name: "employeeterritories",
                schema: "public");

            migrationBuilder.DropTable(
                name: "orderdetails",
                schema: "public");

            migrationBuilder.DropTable(
                name: "customerdemographics",
                schema: "public");

            migrationBuilder.DropTable(
                name: "territories",
                schema: "public");

            migrationBuilder.DropTable(
                name: "orders",
                schema: "public");

            migrationBuilder.DropTable(
                name: "products",
                schema: "public");

            migrationBuilder.DropTable(
                name: "region",
                schema: "public");

            migrationBuilder.DropTable(
                name: "customers",
                schema: "public");

            migrationBuilder.DropTable(
                name: "employees",
                schema: "public");

            migrationBuilder.DropTable(
                name: "shippers",
                schema: "public");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "public");

            migrationBuilder.DropTable(
                name: "suppliers",
                schema: "public");
        }
    }
}
