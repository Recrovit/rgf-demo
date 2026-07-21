using Recrovit.RecroGridFramework;
using Recrovit.RecroGridFramework.Abstraction.Models;
using Recrovit.RecroGridFramework.Extensions;
using Recrovit.RecroGridFramework.Security;
using ScDemo.Northwind.Models;

namespace RecroGridComponents.ScDemo.Northwind;

public partial class RgProduct : RGFDemoRgBase<Product>
{
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
        var dataRec = args.DataRec as Product;
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