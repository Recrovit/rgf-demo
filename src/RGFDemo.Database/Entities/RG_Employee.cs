using Recrovit.RecroGridFramework;
using Recrovit.RecroGridFramework.Core;
using RGF.Demo.Northwind.Models;

namespace RGF.Demo.Northwind.Entities
{
    public partial class RG_Employee : RgfCore<Employees>
    {
        public RG_Employee(IRecroGridContext rgContext) : base(rgContext) { }
    }
}