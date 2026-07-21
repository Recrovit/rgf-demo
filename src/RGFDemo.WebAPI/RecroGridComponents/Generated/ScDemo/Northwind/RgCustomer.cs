using Recrovit.RecroGridFramework;
using ScDemo.Northwind.Models;

namespace RecroGridComponents.ScDemo.Northwind;

public partial class RgCustomer : RGFDemoRgBase<Customer>
{
    public RgCustomer(IRecroGridContext rgContext) : base(rgContext) { }
}