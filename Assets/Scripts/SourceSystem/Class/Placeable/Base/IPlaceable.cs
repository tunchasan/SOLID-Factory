using SourceSystem.Class.Detectable.Base;

namespace SourceSystem.Class.Placeable.Base
{
    public interface IPlaceable : IDetectable
    {
        void UnPossesBy();
    }
}