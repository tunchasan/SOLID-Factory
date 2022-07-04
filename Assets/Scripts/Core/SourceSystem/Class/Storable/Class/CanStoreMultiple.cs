using Factorio.Core.SourceSystem.Class.Storable.Base;
using Factorio.Core.StorageSystem.Utilities;
using UnityEngine;

namespace Factorio.Core.SourceSystem.Class.Storable.Class
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