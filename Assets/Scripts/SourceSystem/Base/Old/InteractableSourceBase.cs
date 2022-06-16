using ConveyorBeltSystem.Base;
using PlacerSystem.Base;
using StorageSystem.Base;
using StorageSystem.Utilities;
using UnityEngine;

namespace SourceSystem.Base.Old
{
    public abstract class InteractableSourceBase : SourceBase, IStorable, IPlaceable, ITransportable
    {
        public bool Status { get; protected set; } = true;
        public EntityType Type { get; protected set; } = EntityType.Source;
        public abstract void PossesBy(Transform instigator);
        public abstract void UnPossesBy();
        public virtual GameObject GetTarget()
        {
            return gameObject;
        }
    }
}