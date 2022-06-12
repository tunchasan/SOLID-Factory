using ConveyorBeltSystem.Base;
using PlacerSystem.Base;
using StorageSystem.Base;
using StorageSystem.Utilities;
using UnityEngine;

namespace SourceSystem.Base
{
    public abstract class InteractableSourceBase : SourceBase, IStorable, IPlaceable, ITransportable
    {
        public bool CanStorable { get; protected set; } = true;
        public StorageType Type { get; protected set; } = StorageType.Source;
        
        public virtual void PossesBy(Transform instigator)
        {
            transform.SetParent(instigator);           
        }

        public virtual void UnPossesBy()
        {
            transform.SetParent(null);
        }

        public virtual GameObject GetTarget()
        {
            return gameObject;
        }
    }
}