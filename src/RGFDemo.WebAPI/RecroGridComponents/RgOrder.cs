using Microsoft.EntityFrameworkCore;
using Recrovit.RecroGridFramework;
using Recrovit.RecroGridFramework.Abstraction.Models;
using Recrovit.RecroGridFramework.Data;
using Recrovit.RecroGridFramework.Extensions;
using RGFDemo.Database;
using ScDemo.Northwind.Models;

namespace RecroGridComponents.ScDemo.Northwind;

public partial class RgOrder : RGFDemoRgBase<Order>
{
    protected override async Task InitializeAsync(IRecroGridContext rgContext)
    {
        await base.InitializeAsync(rgContext);

        RgfMenu menu = new();
        menu.AddItem("10% discount", "discount10");
        RGOptions["RGO_CustomMenu"] = menu;
    }

    protected override async Task<bool> OnCustomFunctionAsync(RecroTrack tracking, CustomFunctionEventArgs args, RGUIMessages messages)
    {
        var dataRec = args.DataRec as Order;
        if (dataRec != null)
        {
            switch (args.FunctionName)
            {
                case "discount10":
                    using (var trans = tracking.RGDataContext.BeginTransaction())
                    {
                        tracking.TransactionComment = "10% discount";
                        var dbContext = tracking.RGDataContext.GetContext<RGFDemoDbContext>();
                        var order = await dbContext.Order.SingleOrDefaultAsync(e => e.OrderId == dataRec.OrderId);
                        if (order != null)
                        {
                            if (order.Freight != null)
                            {
                                order.Freight -= order.Freight / 10;
                                await tracking.SaveChangesAsync();
                            }
                            foreach (var item in await dbContext.OrderDetail.Where(e => e.OrderId == dataRec.OrderId).ToArrayAsync())
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