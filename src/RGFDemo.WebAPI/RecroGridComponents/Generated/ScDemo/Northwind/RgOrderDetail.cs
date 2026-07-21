using Recrovit.RecroGridFramework;
using ScDemo.Northwind.Models;

namespace RecroGridComponents.ScDemo.Northwind;

public partial class RgOrderDetail : RGFDemoRgBase<OrderDetail>
{
    public RgOrderDetail(IRecroGridContext rgContext) : base(rgContext) { }
}