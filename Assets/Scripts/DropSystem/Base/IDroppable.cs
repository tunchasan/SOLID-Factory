using DetectorSystem.Base;

namespace DropSystem.Base
{
    public interface IDroppable : IDetectable
    {
        void UnPossesBy();
    }
}