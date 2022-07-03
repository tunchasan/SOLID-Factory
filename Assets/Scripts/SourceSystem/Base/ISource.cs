using DetectorSystem.Base;
using PlacerSystem.Base;
using SourceSystem.Class;
using SourceSystem.Class.Detectable.Base;
using SourceSystem.Class.Placeable.Base;
using SourceSystem.Class.Processable.Base;
using SourceSystem.Class.Storable.Base;
using SourceSystem.Class.Transportable.Base;
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