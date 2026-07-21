using Recrovit.RecroGridFramework;
using ScDemo.Northwind.Models;

namespace RecroGridComponents.ScDemo.Northwind;

public partial class RgEmployee : RGFDemoRgBase<Employee>
{
    public RgEmployee(IRecroGridContext rgContext) : base(rgContext) { }
}