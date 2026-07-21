using Recrovit.RecroGridFramework;
using ScDemo.Northwind.Models;

namespace RecroGridComponents.ScDemo.Northwind;

public partial class RgProduct : RGFDemoRgBase<Product>
{
    public RgProduct(IRecroGridContext rgContext) : base(rgContext) { }
}