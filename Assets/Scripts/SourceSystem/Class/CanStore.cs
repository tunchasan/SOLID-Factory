using StorageSystem.Base;
using StorageSystem.Utilities;
using UnityEngine;

namespace SourceSystem.Class
{
    public abstract class CanStore : IStorable
    {
        protected readonly GameObject Target = null;
        public bool Status { get; protected set; } = false;
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