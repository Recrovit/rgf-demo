using Recrovit.RecroGridFramework;
using ScDemo.Northwind.Models;

namespace RecroGridComponents.ScDemo.Northwind;

public partial class RgOrder : RGFDemoRgBase<Order>
{
    public RgOrder(IRecroGridContext rgContext) : base(rgContext) { }
}