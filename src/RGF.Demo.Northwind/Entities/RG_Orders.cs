using Microsoft.EntityFrameworkCore;
using Recrovit.RecroGridFramework;
using Recrovit.RecroGridFramework.Abstraction.Models;
using Recrovit.RecroGridFramework.Core;
using Recrovit.RecroGridFramework.Data;
using Recrovit.RecroGridFramework.Extensions;
using RGF.Demo.Northwind.Models;

namespace RGF.Demo.Northwind.Entities;

public partial class RG_Orders : RgfCore<Orders>
{
    public RG_Orders(IRecroGridContext rgContext) : base(rgContext) { }

    protected override async Task InitializeAsync(IRecroGridContext rgContext)
    {
        await base.InitializeAsync(rgContext);

        RgfMenu menu = new();
        menu.AddItem("10% discount", "discount10");
        RGOptions["RGO_CustomMenu"] = menu;
    }

    protected override async Task<bool> OnCustomFunctionAsync(RecroTrack tracking, CustomFunctionEventArgs args, RGUIMessages messages)
    {
        var dataRec = args.DataRec as Orders;
        if (dataRec != null)
        {
            switch (args.FunctionName)
            {
                case "discount10":
                    using (var trans = tracking.RGDataContext.BeginTransaction())
                    {
                        tracking.TransactionComment = "10% discount";
                        var dbContext = tracking.RGDataContext.GetContext<NorthwindDbContext>();
                        var order = await dbContext.Orders.SingleOrDefaultAsync(e => e.OrderID == dataRec.OrderID);
                        if (order != null)
                        {
                            if (order.Freight != null)
                            {
                                order.Freight -= order.Freight / 10;
                                await tracking.SaveChangesAsync();
                            }
                            foreach (var item in await dbContext.OrderDetails.Where(e => e.OrderId == dataRec.OrderID).ToArrayAsync())
                            {
                                item.Discount = 0.1f;
                                item.UnitPrice = item.UnitPrice * 1.1m;
                                await tracking.SaveChangesAsync();
                            }

                            await trans.CommitAsync();
                            messages.AddInfo("10% discount applied");
                            args.RefreshRow = true;
                            return true;
                        }
                    }
                    break;
            }
        }
        return await base.OnCustomFunctionAsync(tracking, args, messages);
    }
}