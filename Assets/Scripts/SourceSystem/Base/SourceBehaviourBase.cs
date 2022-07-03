using DetectorSystem.Base;
using PlacerSystem.Base;
using SourceSystem.Class;
using SourceSystem.Class.Detectable.Base;
using SourceSystem.Class.Placeable.Base;
using SourceSystem.Class.Processable.Base;
using SourceSystem.Class.Storable.Base;
using SourceSystem.Class.Transportable.Base;
using StorageSystem.Base;
using UnityEngine;

namespace SourceSystem.Base
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