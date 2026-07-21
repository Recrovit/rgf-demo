using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RGFDemo.Database.Data.Migrations.PostgreSQL
{
    /// <inheritdoc />
    public partial class RGFDemoDatabase_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    categoryid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    categoryname = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    picture = table.Column<byte[]>(type: "bytea", nullable: true),
                    rowversion = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.categoryid);
                });

            migrationBuilder.CreateTable(
                name: "customerdemographics",
                columns: table => new
                {
                    customerdemographicid = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    customerdesc = table.Column<string>(type: "text", nullable: true),
                    rowversion = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customerdemographics", x => x.customerdemographicid);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    customerid = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
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
                    rowversion = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customers", x => x.customerid);
                });

            migrationBuilder.CreateTable(
                name: "employees",
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
                    photopath = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    rowversion = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    reportsto = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employees", x => x.employeeid);
                    table.ForeignKey(
                        name: "fk_employee_employee_reportsto",
                        column: x => x.reportsto,
                        principalTable: "employees",
                        principalColumn: "employeeid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "region",
                columns: table => new
                {
                    regionid = table.Column<int>(type: "integer", nullable: false),
                    regiondescription = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    rowversion = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_region", x => x.regionid);
                });

            migrationBuilder.CreateTable(
                name: "shippers",
                columns: table => new
                {
                    shipperid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    companyname = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    phone = table.Column<string>(type: "character varying(24)", maxLength: 24, nullable: true),
                    rowversion = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_shippers", x => x.shipperid);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
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
                    rowversion = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_suppliers", x => x.supplierid);
                });

            migrationBuilder.CreateTable(
                name: "customercustomerdemo",
                columns: table => new
                {
                    customercustomerdemoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rowversion = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    customerid = table.Column<string>(type: "character varying(5)", nullable: false),
                    customertypeid = table.Column<string>(type: "character varying(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customercustomerdemo", x => x.customercustomerdemoid);
                    table.ForeignKey(
                        name: "fk_customercustomerdemo_customer_customerid",
                        column: x => x.customerid,
                        principalTable: "customers",
                        principalColumn: "customerid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_customercustomerdemo_customerdemographic_customertypeid",
                        column: x => x.customertypeid,
                        principalTable: "customerdemographics",
                        principalColumn: "customerdemographicid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "territories",
                columns: table => new
                {
                    territoryid = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    territorydescription = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    rowversion = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    regionid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_territories", x => x.territoryid);
                    table.ForeignKey(
                        name: "fk_territory_region_regionid",
                        column: x => x.regionid,
                        principalTable: "region",
                        principalColumn: "regionid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    orderid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    orderdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    requireddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    shippeddate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    freight = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true, defaultValueSql: "0"),
                    shipname = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    shipaddress = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    shipcity = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    shipregion = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    shippostalcode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    shipcountry = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    rowversion = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    customerid = table.Column<string>(type: "character varying(5)", nullable: false),
                    employeeid = table.Column<int>(type: "integer", nullable: true),
                    shipvia = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.orderid);
                    table.ForeignKey(
                        name: "fk_order_customer_customerid",
                        column: x => x.customerid,
                        principalTable: "customers",
                        principalColumn: "customerid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_order_employee_employeeid",
                        column: x => x.employeeid,
                        principalTable: "employees",
                        principalColumn: "employeeid",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_order_shipper_shipvia",
                        column: x => x.shipvia,
                        principalTable: "shippers",
                        principalColumn: "shipperid",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    productid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    productname = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    quantityperunit = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    unitprice = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: true, defaultValueSql: "0"),
                    unitsinstock = table.Column<short>(type: "smallint", nullable: true, defaultValueSql: "0"),
                    unitsonorder = table.Column<short>(type: "smallint", nullable: true, defaultValueSql: "0"),
                    reorderlevel = table.Column<short>(type: "smallint", nullable: true, defaultValueSql: "0"),
                    discontinued = table.Column<bool>(type: "boolean", nullable: false),
                    rowversion = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    categoryid = table.Column<int>(type: "integer", nullable: true),
                    supplierid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.productid);
                    table.ForeignKey(
                        name: "fk_product_category_categoryid",
                        column: x => x.categoryid,
                        principalTable: "categories",
                        principalColumn: "categoryid",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_product_supplier_supplierid",
                        column: x => x.supplierid,
                        principalTable: "suppliers",
                        principalColumn: "supplierid",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "employeeterritories",
                columns: table => new
                {
                    employeeterritoryid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rowversion = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    employeeid = table.Column<int>(type: "integer", nullable: false),
                    territoryid = table.Column<string>(type: "character varying(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employeeterritories", x => x.employeeterritoryid);
                    table.ForeignKey(
                        name: "fk_employeeterritory_employee_employeeid",
                        column: x => x.employeeid,
                        principalTable: "employees",
                        principalColumn: "employeeid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_employeeterritory_territory_territoryid",
                        column: x => x.territoryid,
                        principalTable: "territories",
                        principalColumn: "territoryid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orderdetails",
                columns: table => new
                {
                    orderdetailid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    unitprice = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    quantity = table.Column<short>(type: "smallint", nullable: false),
                    discount = table.Column<double>(type: "double precision", nullable: false),
                    rowversion = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    orderid = table.Column<int>(type: "integer", nullable: false),
                    productid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orderdetails", x => x.orderdetailid);
                    table.ForeignKey(
                        name: "fk_orderdetail_order_orderid",
                        column: x => x.orderid,
                        principalTable: "orders",
                        principalColumn: "orderid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_orderdetail_product_productid",
                        column: x => x.productid,
                        principalTable: "products",
                        principalColumn: "productid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_scdemo_northwind_category_categoryname",
                table: "categories",
                column: "categoryname");

            migrationBuilder.CreateIndex(
                name: "ix_customercustomerdemo_customerid",
                table: "customercustomerdemo",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "ix_customercustomerdemo_customertypeid",
                table: "customercustomerdemo",
                column: "customertypeid");

            migrationBuilder.CreateIndex(
                name: "ix_scdemo_northwind_customer_city",
                table: "customers",
                column: "city");

            migrationBuilder.CreateIndex(
                name: "ix_scdemo_northwind_customer_companyname",
                table: "customers",
                column: "companyname");

            migrationBuilder.CreateIndex(
                name: "ix_scdemo_northwind_customer_postalcode",
                table: "customers",
                column: "postalcode");

            migrationBuilder.CreateIndex(
                name: "ix_scdemo_northwind_customer_region",
                table: "customers",
                column: "region");

            migrationBuilder.CreateIndex(
                name: "ix_employees_reportsto",
                table: "employees",
                column: "reportsto");

            migrationBuilder.CreateIndex(
                name: "ix_scdemo_northwind_employee_lastname",
                table: "employees",
                column: "lastname");

            migrationBuilder.CreateIndex(
                name: "ix_scdemo_northwind_employee_postalcode",
                table: "employees",
                column: "postalcode");

            migrationBuilder.CreateIndex(
                name: "ix_employeeterritories_employeeid",
                table: "employeeterritories",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "ix_employeeterritories_territoryid",
                table: "employeeterritories",
                column: "territoryid");

            migrationBuilder.CreateIndex(
                name: "ix_orderdetails_orderid",
                table: "orderdetails",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "ix_orderdetails_productid",
                table: "orderdetails",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_orders_customerid",
                table: "orders",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "ix_orders_employeeid",
                table: "orders",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "ix_orders_shipvia",
                table: "orders",
                column: "shipvia");

            migrationBuilder.CreateIndex(
                name: "ix_scdemo_northwind_order_orderdate",
                table: "orders",
                column: "orderdate");

            migrationBuilder.CreateIndex(
                name: "ix_scdemo_northwind_order_shippeddate",
                table: "orders",
                column: "shippeddate");

            migrationBuilder.CreateIndex(
                name: "ix_scdemo_northwind_order_shippostalcode",
                table: "orders",
                column: "shippostalcode");

            migrationBuilder.CreateIndex(
                name: "ix_products_categoryid",
                table: "products",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "ix_products_supplierid",
                table: "products",
                column: "supplierid");

            migrationBuilder.CreateIndex(
                name: "ix_scdemo_northwind_product_productname",
                table: "products",
                column: "productname");

            migrationBuilder.CreateIndex(
                name: "ix_scdemo_northwind_shipper_companyname",
                table: "shippers",
                column: "companyname");

            migrationBuilder.CreateIndex(
                name: "ix_scdemo_northwind_supplier_companyname",
                table: "suppliers",
                column: "companyname");

            migrationBuilder.CreateIndex(
                name: "ix_scdemo_northwind_supplier_postalcode",
                table: "suppliers",
                column: "postalcode");

            migrationBuilder.CreateIndex(
                name: "ix_territories_regionid",
                table: "territories",
                column: "regionid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customercustomerdemo");

            migrationBuilder.DropTable(
                name: "employeeterritories");

            migrationBuilder.DropTable(
                name: "orderdetails");

            migrationBuilder.DropTable(
                name: "customerdemographics");

            migrationBuilder.DropTable(
                name: "territories");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "region");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "shippers");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "suppliers");
        }
    }
}
