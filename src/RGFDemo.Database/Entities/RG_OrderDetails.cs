using Recrovit.RecroGridFramework;
using Recrovit.RecroGridFramework.Abstraction.Models;
using Recrovit.RecroGridFramework.Core;
using Recrovit.RecroGridFramework.Data;
using RGF.Demo.Northwind.Common.Validation;
using RGF.Demo.Northwind.Models;

namespace RGF.Demo.Northwind.Entities;

public partial class RG_OrderDetails : RgfCore<Order_Details>
{
    public RG_OrderDetails(IRecroGridContext rgContext) : base(rgContext) { }

    public override async Task<bool> OnValidationAsync(IRGDataContext context, Order_Details dataRec, RGClientParam param, RGUIMessages messages)
    {
        //if (dataRec.Discount != 0 && (dataRec.Discount < 0.01 || dataRec.Discount > 0.9))
        //{
        //    messages.AddFieldErrorMessage("discount", "Discount must be between 0.01 and 0.9");
        //    messages.AddFormErrorMessage("Server-side validation");
        //}

        await OrderDetailValidation.ValidateAsync(RgfDynamicDictionary.Create(dataRec, StringComparer.OrdinalIgnoreCase), messages, RecroDictService);
        return await base.OnValidationAsync(context, dataRec, param, messages);
    }
}