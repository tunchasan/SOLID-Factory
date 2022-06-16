using ConveyorBeltSystem.Base;
using DetectorSystem.Base;
using PlacerSystem.Base;
using StorageSystem.Base;

namespace SourceSystem.Base
{
    public interface ISource
    {
        IStorable IsStorable();
        IPlaceable IsPlaceable();
        IDetectable IsDetectable();
        ITransportable IsTransportable();
    }
}