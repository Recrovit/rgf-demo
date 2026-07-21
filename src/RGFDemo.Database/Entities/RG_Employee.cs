using Recrovit.RecroGridFramework;
using Recrovit.RecroGridFramework.Core;
using RGF.Demo.Northwind.Models;

namespace RGFDemo.Database.Entities
{
    public partial class RG_Employee : RgfCore<Employees>
    {
        public RG_Employee(IRecroGridContext rgContext) : base(rgContext) { }
    }
}