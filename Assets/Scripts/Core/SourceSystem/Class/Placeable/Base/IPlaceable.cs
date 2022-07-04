using Factorio.Core.SourceSystem.Class.Detectable.Base;

namespace Factorio.Core.SourceSystem.Class.Placeable.Base
{
    public interface IPlaceable : IDetectable
    {
        void UnPossesBy();
    }
}