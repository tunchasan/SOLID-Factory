using SourceSystem.Class.Storable.Base;
using StorageSystem.Utilities;
using UnityEngine;

namespace SourceSystem.Class.Storable.Class
{
    public class CanStoreSingle : CanStore
    {
        public CanStoreSingle(GameObject target, EntityType type) : base(target, type)
        {
            
        }
        public override void PossesBy(Transform instigator)
        {
            if (Status)
            {
                Status = false;
                
                Target.transform.SetParent(instigator);
            }
        }
    }
}