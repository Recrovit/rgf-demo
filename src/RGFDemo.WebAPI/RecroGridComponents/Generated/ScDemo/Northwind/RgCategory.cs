using Recrovit.RecroGridFramework;
using ScDemo.Northwind.Models;

namespace RecroGridComponents.ScDemo.Northwind;

public partial class RgCategory : RGFDemoRgBase<Category>
{
    public RgCategory(IRecroGridContext rgContext) : base(rgContext) { }
}