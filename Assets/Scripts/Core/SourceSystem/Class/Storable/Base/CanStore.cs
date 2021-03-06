using Factorio.Core.StorageSystem.Utilities;
using UnityEngine;

namespace Factorio.Core.SourceSystem.Class.Storable.Base
{
    public abstract class CanStore : IStorable
    {
        protected readonly GameObject Target = null;
        public bool Status { get; protected set; } = true;
        public EntityType Type { get; }
        protected CanStore(GameObject target, EntityType type)
        {
            Target = target;
            Type = type;
        }
        public GameObject GetTarget()
        {
            return Target;
        }
        public abstract void PossesBy(Transform instigator);
    }
}