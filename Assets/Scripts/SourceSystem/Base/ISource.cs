using ConveyorBeltSystem.Base;
using DetectorSystem.Base;
using PlacerSystem.Base;
using SourceSystem.Class;
using StorageSystem.Base;

namespace SourceSystem.Base
{
    public interface ISource
    {
        void UpdateBehaviour(SourceConfigDataBase config);
        IStorable IsStorable();
        IPlaceable IsPlaceable();
        IDetectable IsDetectable();
        ITransportable IsTransportable();
        IProcessable IsProcessable();
    }
}