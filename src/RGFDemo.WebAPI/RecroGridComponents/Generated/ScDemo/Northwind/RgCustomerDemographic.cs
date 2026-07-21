using Recrovit.RecroGridFramework;
using ScDemo.Northwind.Models;

namespace RecroGridComponents.ScDemo.Northwind;

public partial class RgCustomerDemographic : RGFDemoRgBase<CustomerDemographic>
{
    public RgCustomerDemographic(IRecroGridContext rgContext) : base(rgContext) { }
}