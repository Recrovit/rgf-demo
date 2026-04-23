#nullable disable
using System.ComponentModel.DataAnnotations.Schema;

namespace RGF.Demo.Northwind.Models;

public partial class Categories
{
    public Categories()
    {
        Products = new HashSet<Products>();
    }

    public int CategoryID { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
    public byte[] Picture { get; set; }
    public int rowversion { get; set; }
    public int? DropdownStatic { get; set; }
    public int? DropdownRecroDict { get; set; }
    public int? DropdownEnum { get; set; }
    public int? DropdownCallback { get; set; }

    public ICollection<Products> Products { get; set; }
}

public partial class CustomerCustomerDemo
{
    public string CustomerID { get; set; }
    public string CustomerTypeID { get; set; }
    public int rowversion { get; set; }

    public Customers Customer { get; set; }
    public CustomerDemographics CustomerType { get; set; }
}

public partial class CustomerDemographics
{
    public CustomerDemographics()
    {
        CustomerCustomerDemo = new HashSet<CustomerCustomerDemo>();
    }

    public string CustomerTypeID { get; set; }
    public string CustomerDesc { get; set; }
    public int rowversion { get; set; }

    public ICollection<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }
}

public partial class Customers
{
    public Customers()
    {
        CustomerCustomerDemo = new HashSet<CustomerCustomerDemo>();
        Orders = new HashSet<Orders>();
    }

    public string CustomerID { get; set; }
    public string CompanyName { get; set; }
    public string ContactName { get; set; }
    public string ContactTitle { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public int rowversion { get; set; }

    public ICollection<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }
    public ICollection<Orders> Orders { get; set; }
}

public partial class Employees
{
    public Employees()
    {
        EmployeeTerritories = new HashSet<EmployeeTerritories>();
        Employees1 = new HashSet<Employees>();
        Orders = new HashSet<Orders>();
    }

    public int EmployeeID { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Title { get; set; }
    public string TitleOfCourtesy { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? HireDate { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string HomePhone { get; set; }
    public string Extension { get; set; }
    public byte[] Photo { get; set; }
    public string Notes { get; set; }
    public int? ReportsTo { get; set; }
    public string PhotoPath { get; set; }
    public int rowversion { get; set; }

    public Employees Employees2 { get; set; }
    public ICollection<EmployeeTerritories> EmployeeTerritories { get; set; }
    public ICollection<Employees> Employees1 { get; set; }
    public ICollection<Orders> Orders { get; set; }
}

public partial class EmployeeTerritories
{
    public int EmployeeID { get; set; }
    public string TerritoryID { get; set; }
    public int rowversion { get; set; }

    public Employees Employees { get; set; }
    public Territories Territories { get; set; }
}

public partial class Order_Details
{
    public int OrderId { get; set; }
    public int ProductID { get; set; }
    public decimal UnitPrice { get; set; }
    public short Quantity { get; set; }
    public float Discount { get; set; }
    public int rowversion { get; set; }

    [ForeignKey(nameof(OrderId))]
    [InverseProperty(nameof(Models.Orders.Order_Details))]
    public Orders Orders { get; set; }

    public Products Products { get; set; }
}

public partial class Orders
{
    public Orders()
    {
        Order_Details = new HashSet<Order_Details>();
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public int? EmployeeID { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? RequiredDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public int? ShipVia { get; set; }
    public decimal? Freight { get; set; }
    public string ShipName { get; set; }
    public string ShipAddress { get; set; }
    public string ShipCity { get; set; }
    public string ShipRegion { get; set; }
    public string ShipPostalCode { get; set; }
    public string ShipCountry { get; set; }
    public int rowversion { get; set; }

    public Customers Customers { get; set; }
    public Employees Employees { get; set; }
    public Shippers Shippers { get; set; }

    [InverseProperty(nameof(Models.Order_Details.Orders))]
    public ICollection<Order_Details> Order_Details { get; set; }
}

public partial class Products
{
    public Products()
    {
        Order_Details = new HashSet<Order_Details>();
    }

    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public int? SupplierID { get; set; }
    public int? CategoryID { get; set; }
    public string QuantityPerUnit { get; set; }
    public decimal? UnitPrice { get; set; }
    public short? UnitsInStock { get; set; }
    public short? UnitsOnOrder { get; set; }
    public short? ReorderLevel { get; set; }
    public bool Discontinued { get; set; }
    public int rowversion { get; set; }

    public Categories Categories { get; set; }
    public Suppliers Suppliers { get; set; }
    public ICollection<Order_Details> Order_Details { get; set; }
}

public partial class Region
{
    public Region()
    {
        Territories = new HashSet<Territories>();
    }

    public int RegionID { get; set; }
    public string RegionDescription { get; set; }
    public int rowversion { get; set; }

    public ICollection<Territories> Territories { get; set; }
}

public partial class Shippers
{
    public Shippers()
    {
        Orders = new HashSet<Orders>();
    }

    public int ShipperID { get; set; }
    public string CompanyName { get; set; }
    public string Phone { get; set; }
    public int rowversion { get; set; }

    public ICollection<Orders> Orders { get; set; }
}

public partial class Suppliers
{
    public Suppliers()
    {
        Products = new HashSet<Products>();
    }

    public int SupplierID { get; set; }
    public string CompanyName { get; set; }
    public string ContactName { get; set; }
    public string ContactTitle { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string HomePage { get; set; }
    public int rowversion { get; set; }

    public ICollection<Products> Products { get; set; }
}

public partial class Territories
{
    public Territories()
    {
        EmployeeTerritories = new HashSet<EmployeeTerritories>();
    }

    public string TerritoryID { get; set; }
    public string TerritoryDescription { get; set; }
    public int RegionID { get; set; }
    public int rowversion { get; set; }

    public Region Region { get; set; }
    public ICollection<EmployeeTerritories> EmployeeTerritories { get; set; }
}
