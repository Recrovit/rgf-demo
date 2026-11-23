using Recrovit.RecroGridFramework;
using ScDemo.Northwind.Models;

namespace RGF.Demo.Northwind.Entities
{
    public partial class RG_Employee : RgBase<Employee>
    {
        public RG_Employee(IRecroGridContext rgContext) : base(rgContext) { }
    }
}