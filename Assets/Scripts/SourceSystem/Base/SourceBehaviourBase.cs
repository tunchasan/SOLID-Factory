using ConveyorBeltSystem.Base;
using DetectorSystem.Base;
using PlacerSystem.Base;
using SourceSystem.Class;
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
        public abstract void SetBehaviour(IStorable storable, IPlaceable placeable, IDetectable detectable, ITransportable transportable);
        public abstract void SetBehaviour(SourceConfigDataBase config, GameObject gameObject);
    }
}