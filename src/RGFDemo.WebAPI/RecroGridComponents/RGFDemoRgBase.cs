using Recrovit.RecroGridFramework;

namespace RecroGridComponents;

public partial class RGFDemoRgBase<TEntity> : RgBase<TEntity> where TEntity : class
{
    public RGFDemoRgBase(IRecroGridContext rgContext) : base(rgContext) { }
}