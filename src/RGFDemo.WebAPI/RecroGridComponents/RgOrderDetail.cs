using Recrovit.RecroGridFramework;
using Recrovit.RecroGridFramework.Abstraction.Models;
using Recrovit.RecroGridFramework.Data;
using ScDemo.Northwind.Models;
using ScDemo.Northwind.OrderDetail;

namespace RecroGridComponents.ScDemo.Northwind;

public partial class RgOrderDetail : RGFDemoRgBase<OrderDetail>
{
    public override async Task<bool> OnValidationAsync(IRGDataContext context, OrderDetail dataRec, RGClientParam param, RGUIMessages messages)
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