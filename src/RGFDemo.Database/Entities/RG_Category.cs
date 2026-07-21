using Recrovit.RecroGridFramework;
using Recrovit.RecroGridFramework.Core;
using RGF.Demo.Northwind.Models;
using System.ComponentModel.DataAnnotations;

namespace RGF.Demo.Northwind.Entities;

public enum DropdownEnumTest
{
    [Display(Name = "Enum Item1")]
    EItem1 = 1,

    [Display(Name = "Enum Item2")]
    EItem2 = 2,

    [Display(Name = "Enum Item3")]
    EItem3 = 3,
}

public partial class RG_Category : RgfCore<Categories>
{
    public RG_Category(IRecroGridContext rgContext) : base(rgContext) { }

    public static List<KeyValuePair<string, string>> DropdownCallbackTest(RGDictionaryCallbackParam param)
    {
        return
        [
            new ("1", "CB Item 1"),
            new ("2", "CB Item 2"),
            new ("3", "CB Item 3"),
        ];
    }
}