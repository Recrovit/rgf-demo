using Recrovit.RecroGridFramework;
using ScDemo.Northwind.Models;

namespace RecroGridComponents.ScDemo.Northwind;

public partial class RgSupplier : RGFDemoRgBase<Supplier>
{
    public RgSupplier(IRecroGridContext rgContext) : base(rgContext) { }
}