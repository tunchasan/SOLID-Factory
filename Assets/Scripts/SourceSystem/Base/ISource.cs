using ConveyorBeltSystem.Base;
using DetectorSystem.Base;
using PlacerSystem.Base;
using StorageSystem.Base;
using UnityEngine;

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