using Recrovit.RecroGridFramework;
using Recrovit.RecroGridFramework.Abstraction.Models;
using Recrovit.RecroGridFramework.Core;
using Recrovit.RecroGridFramework.Extensions;
using Recrovit.RecroGridFramework.Security;
using RGF.Demo.Northwind.Models;

namespace RGF.Demo.Northwind.Entities;

public partial class RG_Product : RgfCore<Products>
{
    public RG_Product(IRecroGridContext rgContext) : base(rgContext) { }

    protected override async Task InitializeAsync(IRecroGridContext rgContext)
    {
        await base.InitializeAsync(rgContext);

        RgfMenu menu = new();
        menu.AddItem("Permission", "perm");
        menu.AddItemGlobal("Permission:Custom", "custom");
        RGOptions["RGO_CustomMenu"] = menu;
    }

    protected override Task<bool> OnCustomFunctionAsync(RecroTrack tracking, CustomFunctionEventArgs args, RGUIMessages messages)
    {
        var dataRec = args.DataRec as Products;
        if (dataRec != null)
        {
            switch (args.FunctionName)
            {
                case "perm":
                    var permission = RecroSec.GetPermissionsForUser(tracking.UserId, "RG_Product", null, dataRec);
                    messages.AddInfo(permission.CRUD);
                    break;
            }
        }
        switch (args.FunctionName)
        {
            case "custom":
                var permission1 = RecroSec.GetPermissionsForUser(tracking.UserId, "RG_Product", null, dataRec);
                messages.AddInfo(permission1.GetPermission("Custom") ? "yes" : "no");
                break;
        }
        return base.OnCustomFunctionAsync(tracking, args, messages);
    }
}