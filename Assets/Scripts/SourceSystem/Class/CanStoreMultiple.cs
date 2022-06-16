using StorageSystem.Utilities;
using UnityEngine;

namespace SourceSystem.Class
{
    public class CanStoreMultiple : CanStore
    {
        public CanStoreMultiple(GameObject target, EntityType type) : base(target, type)
        {
            
        }
        public override void PossesBy(Transform instigator)
        {
            Target.transform.SetParent(instigator);
        }
    }
}