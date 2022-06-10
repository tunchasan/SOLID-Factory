using DetectorSystem.Base;

namespace PlacerSystem.Base
{
    public interface IPlaceable : IDetectable
    {
        void UnPossesBy();
    }
}