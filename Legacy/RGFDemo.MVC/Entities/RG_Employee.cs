using Recrovit.RecroGridFramework;
using Recrovit.RecroGridFramework.Core;
using ScDemo.Northwind.Models;

namespace RGF.Demo.Northwind.Entities
{
    public partial class RG_Employee : RgfCore<Employee>
    {
        public RG_Employee(IRecroGridContext rgContext) : base(rgContext) { }
    }
}