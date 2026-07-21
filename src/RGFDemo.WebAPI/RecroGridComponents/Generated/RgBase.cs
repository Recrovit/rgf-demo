using Recrovit.RecroGridFramework;
using Recrovit.RecroGridFramework.Core;
using Recrovit.RecroGridFramework.Security;

namespace RecroGridComponents;

public partial class RgBase<TEntity> : RgfCore<TEntity> where TEntity : class
{
    public RgBase(IRecroGridContext rgContext) : base(rgContext) { }

    protected string GetCurrentUserId()
    {
        var userId = RecroSec.GetCurrentUserId(RecroGridContext.HttpContext);
        return userId ?? RecroSec.AnonymousId;
    }
}