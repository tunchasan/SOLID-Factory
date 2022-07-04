using Factorio.Core.SourceSystem.Class.Detectable.Base;
using Factorio.Core.SourceSystem.Class.Placeable.Base;
using Factorio.Core.SourceSystem.Class.Processable.Base;
using Factorio.Core.SourceSystem.Class.Storable.Base;
using Factorio.Core.SourceSystem.Class.Transportable.Base;
using UnityEngine;

namespace Factorio.Core.SourceSystem.Base
{
    public abstract class SourceBehaviourBase
    {
        public IStorable Storable { get; protected set; } = null;
        public IPlaceable Placeable { get; protected set; } = null;
        public IDetectable Detectable { get; protected set; } = null;
        public ITransportable Transportable { get; protected set; } = null;
        public IProcessable Processable { get; protected set; } = null;
        public abstract void SetBehaviour(IStorable storable, IPlaceable placeable, 
            IDetectable detectable, ITransportable transportable, IProcessable processable);
        public abstract void SetBehaviour(SourceConfigDataBase config, GameObject gameObject);
    }
}