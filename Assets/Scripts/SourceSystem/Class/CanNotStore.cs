using StorageSystem.Base;
using StorageSystem.Utilities;
using UnityEngine;

namespace SourceSystem.Class
{
    public class CanNotStore : IStorable
    {
        public CanNotStore(EntityType type)
        {
            Type = type;
        }
        public GameObject GetTarget()
        {
            return null;
        }

        public bool Status { get; protected set; } = false;
        public EntityType Type { get; }
        public void PossesBy(Transform instigator)
        {
            // no-op
        }
    }
}