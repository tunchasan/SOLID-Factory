using Factorio.Core.SourceSystem.Class.Detectable.Base;
using Factorio.Core.SourceSystem.Class.Placeable.Base;
using Factorio.Core.SourceSystem.Class.Processable.Base;
using Factorio.Core.SourceSystem.Class.Storable.Base;
using Factorio.Core.SourceSystem.Class.Transportable.Base;

namespace Factorio.Core.SourceSystem.Base
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