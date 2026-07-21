using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Recrovit.RecroGridFramework.Data;
using RGF.Demo.Northwind.Models;
using System;
using System.Linq;

namespace RGF.Demo.Northwind;

public class NorthwindDbContext : DbContext
{
    public NorthwindDbContext() { }
    public NorthwindDbContext(DbContextOptions options) : base(options) { }

    public static readonly ILoggerFactory LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder => { builder.AddNLog(); });

#if DEBUG
    public static readonly bool EnableSensitiveDataLogging = true;
#else
    public static readonly bool EnableSensitiveDataLogging = false;
#endif

    #region DbSet
    public virtual DbSet<Categories> Categories { get; set; }
    public virtual DbSet<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }
    public virtual DbSet<CustomerDemographics> CustomerDemographics { get; set; }
    public virtual DbSet<Customers> Customers { get; set; }
    public virtual DbSet<Employees> Employees { get; set; }
    public virtual DbSet<EmployeeTerritories> EmployeeTerritories { get; set; }
    public virtual DbSet<Order_Details> OrderDetails { get; set; }
    public virtual DbSet<Orders> Orders { get; set; }
    public virtual DbSet<Products> Products { get; set; }
    public virtual DbSet<Region> Region { get; set; }
    public virtual DbSet<Shippers> Shippers { get; set; }
    public virtual DbSet<Suppliers> Suppliers { get; set; }
    public virtual DbSet<Territories> Territories { get; set; }
    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory).EnableSensitiveDataLogging(EnableSensitiveDataLogging);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var dbType = IRGDataContextExtensions.GetDBType(this);
        switch (dbType)
        {
            case DBTypeEnum.SQLServer:
                {
                    modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
                    #region Northwind
                    modelBuilder.Entity<Categories>(entity =>
                    {
                        entity.HasKey(e => e.CategoryID);

                        entity.HasIndex(e => e.CategoryName)
                            .HasDatabaseName("CategoryName");

                        entity.Property(e => e.CategoryID).HasColumnName("CategoryID");

                        entity.Property(e => e.CategoryName)
                            .IsRequired()
                            .HasMaxLength(15);

                        entity.Property(e => e.Description).HasColumnType("ntext");

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");
                    });

                    modelBuilder.Entity<CustomerCustomerDemo>(entity =>
                    {
                        entity.HasKey(e => new { e.CustomerID, e.CustomerTypeID })
                            .IsClustered(false);

                        entity.Property(e => e.CustomerID)
                            .HasColumnName("CustomerID")
                            .HasColumnType("nchar(5)");

                        entity.Property(e => e.CustomerTypeID)
                            .HasColumnName("CustomerTypeID")
                            .HasColumnType("nchar(10)");

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");

                        entity.HasOne(d => d.Customer)
                            .WithMany(p => p.CustomerCustomerDemo)
                            .HasForeignKey(d => d.CustomerID)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_CustomerCustomerDemo_Customers");

                        entity.HasOne(d => d.CustomerType)
                            .WithMany(p => p.CustomerCustomerDemo)
                            .HasForeignKey(d => d.CustomerTypeID)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_CustomerCustomerDemo");
                    });

                    modelBuilder.Entity<CustomerDemographics>(entity =>
                    {
                        entity.HasKey(e => e.CustomerTypeID)
                            .IsClustered(false);

                        entity.Property(e => e.CustomerTypeID)
                            .HasColumnName("CustomerTypeID")
                            .HasColumnType("nchar(10)")
                            .ValueGeneratedNever();

                        entity.Property(e => e.CustomerDesc).HasColumnType("ntext");

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");
                    });

                    modelBuilder.Entity<Customers>(entity =>
                    {
                        entity.HasKey(e => e.CustomerID);

                        entity.HasIndex(e => e.City)
                            .HasDatabaseName("City");

                        entity.HasIndex(e => e.CompanyName)
                            .HasDatabaseName("CompanyName");

                        entity.HasIndex(e => e.PostalCode)
                            .HasDatabaseName("PostalCode");

                        entity.HasIndex(e => e.Region)
                            .HasDatabaseName("Region");

                        entity.Property(e => e.CustomerID)
                            .HasColumnName("CustomerID")
                            .HasColumnType("nchar(5)")
                            .ValueGeneratedNever();

                        entity.Property(e => e.Address).HasMaxLength(60);

                        entity.Property(e => e.City).HasMaxLength(15);

                        entity.Property(e => e.CompanyName)
                            .IsRequired()
                            .HasMaxLength(40);

                        entity.Property(e => e.ContactName).HasMaxLength(30);

                        entity.Property(e => e.ContactTitle).HasMaxLength(30);

                        entity.Property(e => e.Country).HasMaxLength(15);

                        entity.Property(e => e.Fax).HasMaxLength(24);

                        entity.Property(e => e.Phone).HasMaxLength(24);

                        entity.Property(e => e.PostalCode).HasMaxLength(10);

                        entity.Property(e => e.Region).HasMaxLength(15);

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");
                    });

                    modelBuilder.Entity<Employees>(entity =>
                    {
                        entity.HasKey(e => e.EmployeeID);

                        entity.HasIndex(e => e.LastName)
                            .HasDatabaseName("LastName");

                        entity.HasIndex(e => e.PostalCode)
                            .HasDatabaseName("PostalCode");

                        entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");

                        entity.Property(e => e.Address).HasMaxLength(60);

                        entity.Property(e => e.BirthDate).HasColumnType("datetime");

                        entity.Property(e => e.City).HasMaxLength(15);

                        entity.Property(e => e.Country).HasMaxLength(15);

                        entity.Property(e => e.Extension).HasMaxLength(4);

                        entity.Property(e => e.FirstName)
                            .IsRequired()
                            .HasMaxLength(10);

                        entity.Property(e => e.HireDate).HasColumnType("datetime");

                        entity.Property(e => e.HomePhone).HasMaxLength(24);

                        entity.Property(e => e.LastName)
                            .IsRequired()
                            .HasMaxLength(20);

                        entity.Property(e => e.Notes).HasColumnType("ntext");

                        entity.Property(e => e.PhotoPath).HasMaxLength(255);

                        entity.Property(e => e.PostalCode).HasMaxLength(10);

                        entity.Property(e => e.Region).HasMaxLength(15);

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");

                        entity.Property(e => e.Title).HasMaxLength(30);

                        entity.Property(e => e.TitleOfCourtesy).HasMaxLength(25);

                        entity.HasOne(d => d.Employees2)
                            .WithMany(p => p.Employees1)
                            .HasForeignKey(d => d.ReportsTo)
                            .HasConstraintName("FK_Employees_Employees");
                    });

                    modelBuilder.Entity<EmployeeTerritories>(entity =>
                    {
                        entity.HasKey(e => new { e.EmployeeID, e.TerritoryID })
                            .IsClustered(false);

                        entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");

                        entity.Property(e => e.TerritoryID)
                            .HasColumnName("TerritoryID")
                            .HasMaxLength(20);

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");

                        entity.HasOne(d => d.Employees)
                            .WithMany(p => p.EmployeeTerritories)
                            .HasForeignKey(d => d.EmployeeID)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_EmployeeTerritories_Employees");

                        entity.HasOne(d => d.Territories)
                            .WithMany(p => p.EmployeeTerritories)
                            .HasForeignKey(d => d.TerritoryID)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_EmployeeTerritories_Territories");
                    });

                    modelBuilder.Entity<Order_Details>(entity =>
                    {
                        entity.HasKey(e => new { e.OrderId, e.ProductID });

                        entity.ToTable("Order Details");

                        entity.HasIndex(e => e.OrderId)
                            .HasDatabaseName("OrdersOrder_Details");

                        entity.HasIndex(e => e.ProductID)
                            .HasDatabaseName("ProductsOrder_Details");

                        entity.Property(e => e.OrderId).HasColumnName("OrderID");

                        entity.Property(e => e.ProductID).HasColumnName("ProductID");

                        entity.Property(e => e.Discount).HasDefaultValueSql("(0)");

                        entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");

                        entity.Property(e => e.UnitPrice)
                            .HasColumnType("money")
                            .HasDefaultValueSql("(0)");

                        entity.HasOne(d => d.Orders)
                            .WithMany(p => p.Order_Details)
                            .HasForeignKey(d => d.OrderId)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_Order_Details_Orders");

                        entity.HasOne(d => d.Products)
                            .WithMany(p => p.Order_Details)
                            .HasForeignKey(d => d.ProductID)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_Order_Details_Products");
                    });

                    modelBuilder.Entity<Orders>(entity =>
                    {
                        entity.HasKey(e => e.OrderID);

                        entity.HasIndex(e => e.CustomerID)
                            .HasDatabaseName("CustomersOrders");

                        entity.HasIndex(e => e.EmployeeID)
                            .HasDatabaseName("EmployeesOrders");

                        entity.HasIndex(e => e.OrderDate)
                            .HasDatabaseName("OrderDate");

                        entity.HasIndex(e => e.ShipPostalCode)
                            .HasDatabaseName("ShipPostalCode");

                        entity.HasIndex(e => e.ShipVia)
                            .HasDatabaseName("ShippersOrders");

                        entity.HasIndex(e => e.ShippedDate)
                            .HasDatabaseName("ShippedDate");

                        entity.Property(e => e.OrderID).HasColumnName("OrderID");

                        entity.Property(e => e.CustomerID)
                            .HasColumnName("CustomerID")
                            .HasColumnType("nchar(5)");

                        entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");

                        entity.Property(e => e.Freight)
                            .HasColumnType("money")
                            .HasDefaultValueSql("(0)");

                        entity.Property(e => e.OrderDate).HasColumnType("datetime");

                        entity.Property(e => e.RequiredDate).HasColumnType("datetime");

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");

                        entity.Property(e => e.ShipAddress).HasMaxLength(60);

                        entity.Property(e => e.ShipCity).HasMaxLength(15);

                        entity.Property(e => e.ShipCountry).HasMaxLength(15);

                        entity.Property(e => e.ShipName).HasMaxLength(40);

                        entity.Property(e => e.ShipPostalCode).HasMaxLength(10);

                        entity.Property(e => e.ShipRegion).HasMaxLength(15);

                        entity.Property(e => e.ShippedDate).HasColumnType("datetime");

                        entity.HasOne(d => d.Customers)
                            .WithMany(p => p.Orders)
                            .HasForeignKey(d => d.CustomerID)
                            .HasConstraintName("FK_Orders_Customers");

                        entity.HasOne(d => d.Employees)
                            .WithMany(p => p.Orders)
                            .HasForeignKey(d => d.EmployeeID)
                            .HasConstraintName("FK_Orders_Employees");

                        entity.HasOne(d => d.Shippers)
                            .WithMany(p => p.Orders)
                            .HasForeignKey(d => d.ShipVia)
                            .HasConstraintName("FK_Orders_Shippers");
                    });

                    modelBuilder.Entity<Products>(entity =>
                    {
                        entity.HasKey(e => e.ProductID);

                        entity.HasIndex(e => e.CategoryID)
                            .HasDatabaseName("CategoryID");

                        entity.HasIndex(e => e.ProductName)
                            .HasDatabaseName("ProductName");

                        entity.HasIndex(e => e.SupplierID)
                            .HasDatabaseName("SuppliersProducts");

                        entity.Property(e => e.ProductID).HasColumnName("ProductID");

                        entity.Property(e => e.CategoryID).HasColumnName("CategoryID");

                        entity.Property(e => e.ProductName)
                            .IsRequired()
                            .HasMaxLength(40);

                        entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);

                        entity.Property(e => e.ReorderLevel).HasDefaultValueSql("(0)");

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");

                        entity.Property(e => e.SupplierID).HasColumnName("SupplierID");

                        entity.Property(e => e.UnitPrice)
                            .HasColumnType("money")
                            .HasDefaultValueSql("(0)");

                        entity.Property(e => e.UnitsInStock).HasDefaultValueSql("(0)");

                        entity.Property(e => e.UnitsOnOrder).HasDefaultValueSql("(0)");

                        entity.HasOne(d => d.Categories)
                            .WithMany(p => p.Products)
                            .HasForeignKey(d => d.CategoryID)
                            .HasConstraintName("FK_Products_Categories");

                        entity.HasOne(d => d.Suppliers)
                            .WithMany(p => p.Products)
                            .HasForeignKey(d => d.SupplierID)
                            .HasConstraintName("FK_Products_Suppliers");
                    });

                    modelBuilder.Entity<Region>(entity =>
                    {
                        entity.Property(e => e.RegionID)
                            .HasColumnName("RegionID")
                            .ValueGeneratedNever();

                        entity.Property(e => e.RegionDescription)
                            .IsRequired()
                            .HasColumnType("nchar(50)");

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");
                    });

                    modelBuilder.Entity<Shippers>(entity =>
                    {
                        entity.HasKey(e => e.ShipperID);

                        entity.Property(e => e.ShipperID).HasColumnName("ShipperID");

                        entity.Property(e => e.CompanyName)
                            .IsRequired()
                            .HasMaxLength(40);

                        entity.Property(e => e.Phone).HasMaxLength(24);

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");
                    });

                    modelBuilder.Entity<Suppliers>(entity =>
                    {
                        entity.HasKey(e => e.SupplierID);

                        entity.HasIndex(e => e.CompanyName)
                            .HasDatabaseName("CompanyName");

                        entity.HasIndex(e => e.PostalCode)
                            .HasDatabaseName("PostalCode");

                        entity.Property(e => e.SupplierID).HasColumnName("SupplierID");

                        entity.Property(e => e.Address).HasMaxLength(60);

                        entity.Property(e => e.City).HasMaxLength(15);

                        entity.Property(e => e.CompanyName)
                            .IsRequired()
                            .HasMaxLength(40);

                        entity.Property(e => e.ContactName).HasMaxLength(30);

                        entity.Property(e => e.ContactTitle).HasMaxLength(30);

                        entity.Property(e => e.Country).HasMaxLength(15);

                        entity.Property(e => e.Fax).HasMaxLength(24);

                        entity.Property(e => e.HomePage).HasColumnType("ntext");

                        entity.Property(e => e.Phone).HasMaxLength(24);

                        entity.Property(e => e.PostalCode).HasMaxLength(10);

                        entity.Property(e => e.Region).HasMaxLength(15);

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");
                    });

                    modelBuilder.Entity<Territories>(entity =>
                    {
                        entity.HasKey(e => e.TerritoryID)
                            .IsClustered(false);

                        entity.Property(e => e.TerritoryID)
                            .HasColumnName("TerritoryID")
                            .HasMaxLength(20)
                            .ValueGeneratedNever();

                        entity.Property(e => e.RegionID).HasColumnName("RegionID");

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");

                        entity.Property(e => e.TerritoryDescription)
                            .IsRequired()
                            .HasColumnType("nchar(50)");

                        entity.HasOne(d => d.Region)
                            .WithMany(p => p.Territories)
                            .HasForeignKey(d => d.RegionID)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_Territories_Region");
                    });
                    #endregion
                }
                break;

            case DBTypeEnum.PostgreSQL:
                {
                    #region Northwind
                    modelBuilder.Entity<Categories>(entity =>
                    {
                        entity.HasKey(e => e.CategoryID);

                        entity.HasIndex(e => e.CategoryName)
                            .HasDatabaseName("IX_Categories_CategoryName");

                        entity.Property(e => e.CategoryID).HasColumnName("CategoryID");

                        entity.Property(e => e.CategoryName)
                            .IsRequired()
                            .HasMaxLength(15);

                        entity.Property(e => e.Description).HasColumnType("text");

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");
                    });

                    modelBuilder.Entity<CustomerCustomerDemo>(entity =>
                    {
                        entity.HasKey(e => new { e.CustomerID, e.CustomerTypeID });

                        entity.Property(e => e.CustomerID)
                            .HasColumnName("CustomerID")
                            .HasColumnType("character(5)");

                        entity.Property(e => e.CustomerTypeID)
                            .HasColumnName("CustomerTypeID")
                            .HasColumnType("character(10)");

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");

                        entity.HasOne(d => d.Customer)
                            .WithMany(p => p.CustomerCustomerDemo)
                            .HasForeignKey(d => d.CustomerID)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_CustomerCustomerDemo_Customers");

                        entity.HasOne(d => d.CustomerType)
                            .WithMany(p => p.CustomerCustomerDemo)
                            .HasForeignKey(d => d.CustomerTypeID)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_CustomerCustomerDemo");
                    });

                    modelBuilder.Entity<CustomerDemographics>(entity =>
                    {
                        entity.HasKey(e => e.CustomerTypeID);

                        entity.Property(e => e.CustomerTypeID)
                            .HasColumnName("CustomerTypeID")
                            .HasColumnType("character(10)")
                            .ValueGeneratedNever();

                        entity.Property(e => e.CustomerDesc).HasColumnType("text");

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");
                    });

                    modelBuilder.Entity<Customers>(entity =>
                    {
                        entity.HasKey(e => e.CustomerID);

                        entity.HasIndex(e => e.City)
                            .HasDatabaseName("IX_Customers_City");

                        entity.HasIndex(e => e.CompanyName)
                            .HasDatabaseName("IX_Customers_CompanyName");

                        entity.HasIndex(e => e.PostalCode)
                            .HasDatabaseName("IX_Customers_PostalCode");

                        entity.HasIndex(e => e.Region)
                            .HasDatabaseName("IX_Customers_Region");

                        entity.Property(e => e.CustomerID)
                            .HasColumnName("CustomerID")
                            .HasColumnType("character(5)")
                            .ValueGeneratedNever();

                        entity.Property(e => e.Address).HasMaxLength(60);

                        entity.Property(e => e.City).HasMaxLength(15);

                        entity.Property(e => e.CompanyName)
                            .IsRequired()
                            .HasMaxLength(40);

                        entity.Property(e => e.ContactName).HasMaxLength(30);

                        entity.Property(e => e.ContactTitle).HasMaxLength(30);

                        entity.Property(e => e.Country).HasMaxLength(15);

                        entity.Property(e => e.Fax).HasMaxLength(24);

                        entity.Property(e => e.Phone).HasMaxLength(24);

                        entity.Property(e => e.PostalCode).HasMaxLength(10);

                        entity.Property(e => e.Region).HasMaxLength(15);

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");
                    });

                    modelBuilder.Entity<Employees>(entity =>
                    {
                        entity.HasKey(e => e.EmployeeID);

                        entity.HasIndex(e => e.LastName)
                            .HasDatabaseName("IX_Employees_LastName");

                        entity.HasIndex(e => e.PostalCode)
                            .HasDatabaseName("IX_Employees_PostalCode");

                        entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");

                        entity.Property(e => e.Address).HasMaxLength(60);

                        entity.Property(e => e.BirthDate).HasColumnType("timestamp without time zone");

                        entity.Property(e => e.City).HasMaxLength(15);

                        entity.Property(e => e.Country).HasMaxLength(15);

                        entity.Property(e => e.Extension).HasMaxLength(4);

                        entity.Property(e => e.FirstName)
                            .IsRequired()
                            .HasMaxLength(10);

                        entity.Property(e => e.HireDate).HasColumnType("timestamp without time zone");

                        entity.Property(e => e.HomePhone).HasMaxLength(24);

                        entity.Property(e => e.LastName)
                            .IsRequired()
                            .HasMaxLength(20);

                        entity.Property(e => e.Notes).HasColumnType("text");

                        entity.Property(e => e.PhotoPath).HasMaxLength(255);

                        entity.Property(e => e.PostalCode).HasMaxLength(10);

                        entity.Property(e => e.Region).HasMaxLength(15);

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");

                        entity.Property(e => e.Title).HasMaxLength(30);

                        entity.Property(e => e.TitleOfCourtesy).HasMaxLength(25);

                        entity.HasOne(d => d.Employees2)
                            .WithMany(p => p.Employees1)
                            .HasForeignKey(d => d.ReportsTo)
                            .HasConstraintName("FK_Employees_Employees");
                    });

                    modelBuilder.Entity<EmployeeTerritories>(entity =>
                    {
                        entity.HasKey(e => new { e.EmployeeID, e.TerritoryID });

                        entity.ToTable("EmployeeTerritories");

                        entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");

                        entity.Property(e => e.TerritoryID)
                            .HasColumnName("TerritoryID")
                            .HasMaxLength(20);

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");

                        entity.HasOne(d => d.Employees)
                            .WithMany(p => p.EmployeeTerritories)
                            .HasForeignKey(d => d.EmployeeID)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_EmployeeTerritories_Employees");

                        entity.HasOne(d => d.Territories)
                            .WithMany(p => p.EmployeeTerritories)
                            .HasForeignKey(d => d.TerritoryID)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_EmployeeTerritories_Territories");
                    });

                    modelBuilder.Entity<Order_Details>(entity =>
                    {
                        entity.HasKey(e => new { e.OrderId, e.ProductID });

                        entity.ToTable("OrderDetails");

                        entity.HasIndex(e => e.OrderId)
                            .HasDatabaseName("IX_OrdersOrder_Details");

                        entity.HasIndex(e => e.ProductID)
                            .HasDatabaseName("IX_OrdersOrder_ProductsOrder_Details");

                        entity.Property(e => e.OrderId).HasColumnName("OrderID");

                        entity.Property(e => e.ProductID).HasColumnName("ProductID");

                        entity.Property(e => e.Discount).HasDefaultValueSql("(0)");

                        entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");

                        entity.Property(e => e.UnitPrice)
                            .HasColumnType("numeric(19,4)")
                            .HasDefaultValueSql("(0)");

                        entity.HasOne(d => d.Orders)
                            .WithMany(p => p.Order_Details)
                            .HasForeignKey(d => d.OrderId)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_Order_Details_Orders");

                        entity.HasOne(d => d.Products)
                            .WithMany(p => p.Order_Details)
                            .HasForeignKey(d => d.ProductID)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_Order_Details_Products");
                    });

                    modelBuilder.Entity<Orders>(entity =>
                    {
                        entity.HasKey(e => e.OrderID);

                        entity.HasIndex(e => e.CustomerID)
                            .HasDatabaseName("IX_Orders_CustomersOrders");

                        entity.HasIndex(e => e.EmployeeID)
                            .HasDatabaseName("IX_Orders_EmployeesOrders");

                        entity.HasIndex(e => e.OrderDate)
                            .HasDatabaseName("IX_Orders_OrderDate");

                        entity.HasIndex(e => e.ShipPostalCode)
                            .HasDatabaseName("IX_Orders_ShipPostalCode");

                        entity.HasIndex(e => e.ShipVia)
                            .HasDatabaseName("IX_Orders_ShippersOrders");

                        entity.HasIndex(e => e.ShippedDate)
                            .HasDatabaseName("IX_Orders_ShippedDate");

                        entity.Property(e => e.OrderID).HasColumnName("OrderID");

                        entity.Property(e => e.CustomerID)
                            .HasColumnName("CustomerID")
                            .HasColumnType("character(5)");

                        entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");

                        entity.Property(e => e.Freight)
                            .HasColumnType("numeric(19,4)")
                            .HasDefaultValueSql("(0)");

                        entity.Property(e => e.OrderDate).HasColumnType("timestamp without time zone");

                        entity.Property(e => e.RequiredDate).HasColumnType("timestamp without time zone");

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");

                        entity.Property(e => e.ShipAddress).HasMaxLength(60);

                        entity.Property(e => e.ShipCity).HasMaxLength(15);

                        entity.Property(e => e.ShipCountry).HasMaxLength(15);

                        entity.Property(e => e.ShipName).HasMaxLength(40);

                        entity.Property(e => e.ShipPostalCode).HasMaxLength(10);

                        entity.Property(e => e.ShipRegion).HasMaxLength(15);

                        entity.Property(e => e.ShippedDate).HasColumnType("timestamp without time zone");

                        entity.HasOne(d => d.Customers)
                            .WithMany(p => p.Orders)
                            .HasForeignKey(d => d.CustomerID)
                            .HasConstraintName("FK_Orders_Customers");

                        entity.HasOne(d => d.Employees)
                            .WithMany(p => p.Orders)
                            .HasForeignKey(d => d.EmployeeID)
                            .HasConstraintName("FK_Orders_Employees");

                        entity.HasOne(d => d.Shippers)
                            .WithMany(p => p.Orders)
                            .HasForeignKey(d => d.ShipVia)
                            .HasConstraintName("FK_Orders_Shippers");
                    });

                    modelBuilder.Entity<Products>(entity =>
                    {
                        entity.HasKey(e => e.ProductID);

                        entity.HasIndex(e => e.CategoryID)
                            .HasDatabaseName("IX_Products_CategoryID");

                        entity.HasIndex(e => e.ProductName)
                            .HasDatabaseName("IX_Products_ProductName");

                        entity.HasIndex(e => e.SupplierID)
                            .HasDatabaseName("IX_Products_SuppliersProducts");

                        entity.Property(e => e.ProductID).HasColumnName("ProductID");

                        entity.Property(e => e.CategoryID).HasColumnName("CategoryID");

                        entity.Property(e => e.ProductName)
                            .IsRequired()
                            .HasMaxLength(40);

                        entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);

                        entity.Property(e => e.ReorderLevel).HasDefaultValueSql("(0)");

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");

                        entity.Property(e => e.SupplierID).HasColumnName("SupplierID");

                        entity.Property(e => e.UnitPrice)
                            .HasColumnType("numeric(19,4)")
                            .HasDefaultValueSql("(0)");

                        entity.Property(e => e.UnitsInStock).HasDefaultValueSql("(0)");

                        entity.Property(e => e.UnitsOnOrder).HasDefaultValueSql("(0)");

                        entity.HasOne(d => d.Categories)
                            .WithMany(p => p.Products)
                            .HasForeignKey(d => d.CategoryID)
                            .HasConstraintName("FK_Products_Categories");

                        entity.HasOne(d => d.Suppliers)
                            .WithMany(p => p.Products)
                            .HasForeignKey(d => d.SupplierID)
                            .HasConstraintName("FK_Products_Suppliers");
                    });

                    modelBuilder.Entity<Region>(entity =>
                    {
                        entity.Property(e => e.RegionID)
                            .HasColumnName("RegionID")
                            .ValueGeneratedNever();

                        entity.Property(e => e.RegionDescription)
                            .IsRequired()
                            .HasColumnType("character(50)");

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");
                    });

                    modelBuilder.Entity<Shippers>(entity =>
                    {
                        entity.HasKey(e => e.ShipperID);

                        entity.Property(e => e.ShipperID).HasColumnName("ShipperID");

                        entity.Property(e => e.CompanyName)
                            .IsRequired()
                            .HasMaxLength(40);

                        entity.Property(e => e.Phone).HasMaxLength(24);

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");
                    });

                    modelBuilder.Entity<Suppliers>(entity =>
                    {
                        entity.HasKey(e => e.SupplierID);

                        entity.HasIndex(e => e.CompanyName)
                            .HasDatabaseName("IX_Suppliers_CompanyName");

                        entity.HasIndex(e => e.PostalCode)
                            .HasDatabaseName("IX_Suppliers_PostalCode");

                        entity.Property(e => e.SupplierID).HasColumnName("SupplierID");

                        entity.Property(e => e.Address).HasMaxLength(60);

                        entity.Property(e => e.City).HasMaxLength(15);

                        entity.Property(e => e.CompanyName)
                            .IsRequired()
                            .HasMaxLength(40);

                        entity.Property(e => e.ContactName).HasMaxLength(30);

                        entity.Property(e => e.ContactTitle).HasMaxLength(30);

                        entity.Property(e => e.Country).HasMaxLength(15);

                        entity.Property(e => e.Fax).HasMaxLength(24);

                        entity.Property(e => e.HomePage).HasColumnType("text");

                        entity.Property(e => e.Phone).HasMaxLength(24);

                        entity.Property(e => e.PostalCode).HasMaxLength(10);

                        entity.Property(e => e.Region).HasMaxLength(15);

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");
                    });

                    modelBuilder.Entity<Territories>(entity =>
                    {
                        entity.HasKey(e => e.TerritoryID);

                        entity.Property(e => e.TerritoryID)
                            .HasColumnName("TerritoryID")
                            .HasMaxLength(20)
                            .ValueGeneratedNever();

                        entity.Property(e => e.RegionID).HasColumnName("RegionID");

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");

                        entity.Property(e => e.TerritoryDescription)
                            .IsRequired()
                            .HasColumnType("character(50)");

                        entity.HasOne(d => d.Region)
                            .WithMany(p => p.Territories)
                            .HasForeignKey(d => d.RegionID)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_Territories_Region");
                    });
                    #endregion
                }
                break;

            case DBTypeEnum.Oracle:
                {
                    #region Northwind
                    modelBuilder.Entity<Categories>(entity =>
                    {
                        entity.HasKey(e => e.CategoryID);

                        entity.HasIndex(e => e.CategoryName)
                            .HasDatabaseName("IX_Categories_CategoryName");

                        entity.Property(e => e.CategoryID).HasColumnName("CategoryID");

                        entity.Property(e => e.CategoryName)
                            .IsRequired()
                            .HasMaxLength(15);

                        entity.Property(e => e.Description).HasColumnType("NCLOB");

                        entity.Property(e => e.Picture).HasColumnType("BLOB");

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");
                    });

                    modelBuilder.Entity<CustomerCustomerDemo>(entity =>
                    {
                        entity.HasKey(e => new { e.CustomerID, e.CustomerTypeID });

                        entity.Property(e => e.CustomerID)
                            .HasColumnName("CustomerID")
                            .HasColumnType("NCHAR(5)");

                        entity.Property(e => e.CustomerTypeID)
                            .HasColumnName("CustomerTypeID")
                            .HasColumnType("NCHAR(10)");

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");

                        entity.HasOne(d => d.Customer)
                            .WithMany(p => p.CustomerCustomerDemo)
                            .HasForeignKey(d => d.CustomerID)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_CustomerCustomerDemo_Cust");

                        entity.HasOne(d => d.CustomerType)
                            .WithMany(p => p.CustomerCustomerDemo)
                            .HasForeignKey(d => d.CustomerTypeID)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_CustomerCustomerDemo");
                    });

                    modelBuilder.Entity<CustomerDemographics>(entity =>
                    {
                        entity.HasKey(e => e.CustomerTypeID);

                        entity.Property(e => e.CustomerTypeID)
                            .HasColumnName("CustomerTypeID")
                            .HasColumnType("NCHAR(10)")
                            .ValueGeneratedNever();

                        entity.Property(e => e.CustomerDesc).HasColumnType("NCLOB");

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");
                    });

                    modelBuilder.Entity<Customers>(entity =>
                    {
                        entity.HasKey(e => e.CustomerID);

                        entity.HasIndex(e => e.City)
                            .HasDatabaseName("IX_Customers_City");

                        entity.HasIndex(e => e.CompanyName)
                            .HasDatabaseName("IX_Customers_CompanyName");

                        entity.HasIndex(e => e.PostalCode)
                            .HasDatabaseName("IX_Customers_PostalCode");

                        entity.HasIndex(e => e.Region)
                            .HasDatabaseName("IX_Customers_Region");

                        entity.Property(e => e.CustomerID)
                            .HasColumnName("CustomerID")
                            .HasColumnType("NCHAR(5)")
                            .ValueGeneratedNever();

                        entity.Property(e => e.Address).HasMaxLength(60);

                        entity.Property(e => e.City).HasMaxLength(15);

                        entity.Property(e => e.CompanyName)
                            .IsRequired()
                            .HasMaxLength(40);

                        entity.Property(e => e.ContactName).HasMaxLength(30);

                        entity.Property(e => e.ContactTitle).HasMaxLength(30);

                        entity.Property(e => e.Country).HasMaxLength(15);

                        entity.Property(e => e.Fax).HasMaxLength(24);

                        entity.Property(e => e.Phone).HasMaxLength(24);

                        entity.Property(e => e.PostalCode).HasMaxLength(10);

                        entity.Property(e => e.Region).HasMaxLength(15);

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");
                    });

                    modelBuilder.Entity<Employees>(entity =>
                    {
                        entity.HasKey(e => e.EmployeeID);

                        entity.HasIndex(e => e.LastName)
                            .HasDatabaseName("IX_Employees_LastName");

                        entity.HasIndex(e => e.PostalCode)
                            .HasDatabaseName("IX_Employees_PostalCode");

                        entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");

                        entity.Property(e => e.Address).HasMaxLength(60);

                        entity.Property(e => e.BirthDate).HasColumnType("timestamp");

                        entity.Property(e => e.City).HasMaxLength(15);

                        entity.Property(e => e.Country).HasMaxLength(15);

                        entity.Property(e => e.Extension).HasMaxLength(4);

                        entity.Property(e => e.FirstName)
                            .IsRequired()
                            .HasMaxLength(10);

                        entity.Property(e => e.HireDate).HasColumnType("timestamp");

                        entity.Property(e => e.HomePhone).HasMaxLength(24);

                        entity.Property(e => e.LastName)
                            .IsRequired()
                            .HasMaxLength(20);

                        entity.Property(e => e.Photo).HasColumnType("BLOB");

                        entity.Property(e => e.Notes).HasColumnType("NCLOB");

                        entity.Property(e => e.PhotoPath).HasMaxLength(255);

                        entity.Property(e => e.PostalCode).HasMaxLength(10);

                        entity.Property(e => e.Region).HasMaxLength(15);

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");

                        entity.Property(e => e.Title).HasMaxLength(30);

                        entity.Property(e => e.TitleOfCourtesy).HasMaxLength(25);

                        entity.HasOne(d => d.Employees2)
                            .WithMany(p => p.Employees1)
                            .HasForeignKey(d => d.ReportsTo)
                            .HasConstraintName("FK_Employees_Employees");
                    });

                    modelBuilder.Entity<EmployeeTerritories>(entity =>
                    {
                        entity.HasKey(e => new { e.EmployeeID, e.TerritoryID });

                        entity.ToTable("EmployeeTerritories");

                        entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");

                        entity.Property(e => e.TerritoryID)
                            .HasColumnName("TerritoryID")
                            .HasMaxLength(20);

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");

                        entity.HasOne(d => d.Employees)
                            .WithMany(p => p.EmployeeTerritories)
                            .HasForeignKey(d => d.EmployeeID)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_EmployeeTerritories_Emp");

                        entity.HasOne(d => d.Territories)
                            .WithMany(p => p.EmployeeTerritories)
                            .HasForeignKey(d => d.TerritoryID)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_EmployeeTerritories_Terr");
                    });

                    modelBuilder.Entity<Order_Details>(entity =>
                    {
                        entity.HasKey(e => new { e.OrderId, e.ProductID });

                        entity.ToTable("OrderDetails");

                        entity.HasIndex(e => e.OrderId)
                            .HasDatabaseName("IX_OrderDetails_OrderId");

                        entity.HasIndex(e => e.ProductID)
                            .HasDatabaseName("IX_OrderDetails_ProductID");

                        entity.Property(e => e.OrderId).HasColumnName("OrderID");

                        entity.Property(e => e.ProductID).HasColumnName("ProductID");

                        entity.Property(e => e.Discount).HasDefaultValueSql("(0)");

                        entity.Property(e => e.Quantity).HasDefaultValue(1);

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");

                        entity.Property(e => e.UnitPrice)
                            .HasColumnType("numeric(19,4)")
                            .HasDefaultValueSql("(0)");

                        entity.HasOne(d => d.Orders)
                            .WithMany(p => p.Order_Details)
                            .HasForeignKey(d => d.OrderId)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_Order_Details_Orders");

                        entity.HasOne(d => d.Products)
                            .WithMany(p => p.Order_Details)
                            .HasForeignKey(d => d.ProductID)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_Order_Details_Products");
                    });

                    modelBuilder.Entity<Orders>(entity =>
                    {
                        entity.HasKey(e => e.OrderID);

                        entity.HasIndex(e => e.CustomerID)
                            .HasDatabaseName("IX_Orders_CustomerID");

                        entity.HasIndex(e => e.EmployeeID)
                            .HasDatabaseName("IX_Orders_EmployeeID");

                        entity.HasIndex(e => e.OrderDate)
                            .HasDatabaseName("IX_Orders_OrderDate");

                        entity.HasIndex(e => e.ShipPostalCode)
                            .HasDatabaseName("IX_Orders_ShipPostalCode");

                        entity.HasIndex(e => e.ShipVia)
                            .HasDatabaseName("IX_Orders_ShipVia");

                        entity.HasIndex(e => e.ShippedDate)
                            .HasDatabaseName("IX_Orders_ShippedDate");

                        entity.Property(e => e.OrderID).HasColumnName("OrderID");

                        entity.Property(e => e.CustomerID)
                            .HasColumnName("CustomerID")
                            .HasColumnType("NCHAR(5)");

                        entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");

                        entity.Property(e => e.Freight)
                            .HasColumnType("numeric(19,4)")
                            .HasDefaultValueSql("(0)");

                        entity.Property(e => e.OrderDate).HasColumnType("timestamp");

                        entity.Property(e => e.RequiredDate).HasColumnType("timestamp");

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");

                        entity.Property(e => e.ShipAddress).HasMaxLength(60);

                        entity.Property(e => e.ShipCity).HasMaxLength(15);

                        entity.Property(e => e.ShipCountry).HasMaxLength(15);

                        entity.Property(e => e.ShipName).HasMaxLength(40);

                        entity.Property(e => e.ShipPostalCode).HasMaxLength(10);

                        entity.Property(e => e.ShipRegion).HasMaxLength(15);

                        entity.Property(e => e.ShippedDate).HasColumnType("timestamp");

                        entity.HasOne(d => d.Customers)
                            .WithMany(p => p.Orders)
                            .HasForeignKey(d => d.CustomerID)
                            .HasConstraintName("FK_Orders_Customers");

                        entity.HasOne(d => d.Employees)
                            .WithMany(p => p.Orders)
                            .HasForeignKey(d => d.EmployeeID)
                            .HasConstraintName("FK_Orders_Employees");

                        entity.HasOne(d => d.Shippers)
                            .WithMany(p => p.Orders)
                            .HasForeignKey(d => d.ShipVia)
                            .HasConstraintName("FK_Orders_Shippers");
                    });

                    modelBuilder.Entity<Products>(entity =>
                    {
                        entity.HasKey(e => e.ProductID);

                        entity.HasIndex(e => e.CategoryID)
                            .HasDatabaseName("IX_Products_CategoryID");

                        entity.HasIndex(e => e.ProductName)
                            .HasDatabaseName("IX_Products_ProductName");

                        entity.HasIndex(e => e.SupplierID)
                            .HasDatabaseName("IX_Products_SupplierID");

                        entity.Property(e => e.ProductID).HasColumnName("ProductID");

                        entity.Property(e => e.CategoryID).HasColumnName("CategoryID");

                        entity.Property(e => e.ProductName)
                            .IsRequired()
                            .HasMaxLength(40);

                        entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);

                        entity.Property(e => e.ReorderLevel).HasDefaultValueSql("(0)");

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");

                        entity.Property(e => e.SupplierID).HasColumnName("SupplierID");

                        entity.Property(e => e.UnitPrice)
                            .HasColumnType("numeric(19,4)")
                            .HasDefaultValueSql("(0)");

                        entity.Property(e => e.UnitsInStock).HasDefaultValueSql("(0)");

                        entity.Property(e => e.UnitsOnOrder).HasDefaultValueSql("(0)");

                        entity.HasOne(d => d.Categories)
                            .WithMany(p => p.Products)
                            .HasForeignKey(d => d.CategoryID)
                            .HasConstraintName("FK_Products_Categories");

                        entity.HasOne(d => d.Suppliers)
                            .WithMany(p => p.Products)
                            .HasForeignKey(d => d.SupplierID)
                            .HasConstraintName("FK_Products_Suppliers");
                    });

                    modelBuilder.Entity<Region>(entity =>
                    {
                        entity.Property(e => e.RegionID)
                            .HasColumnName("RegionID")
                            .ValueGeneratedNever();

                        entity.Property(e => e.RegionDescription)
                            .IsRequired()
                            .HasColumnType("NCHAR(50)");

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");
                    });

                    modelBuilder.Entity<Shippers>(entity =>
                    {
                        entity.HasKey(e => e.ShipperID);

                        entity.Property(e => e.ShipperID).HasColumnName("ShipperID");

                        entity.Property(e => e.CompanyName)
                            .IsRequired()
                            .HasMaxLength(40);

                        entity.Property(e => e.Phone).HasMaxLength(24);

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");
                    });

                    modelBuilder.Entity<Suppliers>(entity =>
                    {
                        entity.HasKey(e => e.SupplierID);

                        entity.HasIndex(e => e.CompanyName)
                            .HasDatabaseName("IX_Suppliers_CompanyName");

                        entity.HasIndex(e => e.PostalCode)
                            .HasDatabaseName("IX_Suppliers_PostalCode");

                        entity.Property(e => e.SupplierID).HasColumnName("SupplierID");

                        entity.Property(e => e.Address).HasMaxLength(60);

                        entity.Property(e => e.City).HasMaxLength(15);

                        entity.Property(e => e.CompanyName)
                            .IsRequired()
                            .HasMaxLength(40);

                        entity.Property(e => e.ContactName).HasMaxLength(30);

                        entity.Property(e => e.ContactTitle).HasMaxLength(30);

                        entity.Property(e => e.Country).HasMaxLength(15);

                        entity.Property(e => e.Fax).HasMaxLength(24);

                        entity.Property(e => e.HomePage).HasColumnType("NCLOB");

                        entity.Property(e => e.Phone).HasMaxLength(24);

                        entity.Property(e => e.PostalCode).HasMaxLength(10);

                        entity.Property(e => e.Region).HasMaxLength(15);

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");
                    });

                    modelBuilder.Entity<Territories>(entity =>
                    {
                        entity.HasKey(e => e.TerritoryID);

                        entity.Property(e => e.TerritoryID)
                            .HasColumnName("TerritoryID")
                            .HasMaxLength(20)
                            .ValueGeneratedNever();

                        entity.Property(e => e.RegionID).HasColumnName("RegionID");

                        entity.Property(e => e.rowversion)
                            .HasColumnName("rowversion")
                            .HasDefaultValueSql("(0)");

                        entity.Property(e => e.TerritoryDescription)
                            .IsRequired()
                            .HasColumnType("NCHAR(50)");

                        entity.HasOne(d => d.Region)
                            .WithMany(p => p.Territories)
                            .HasForeignKey(d => d.RegionID)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_Territories_Region");
                    });
                    #endregion
                }
                break;
        }
    }
}
