using DetectorSystem.Base;
using StorageSystem.Base;
using UnityEngine;

namespace DetectorSystem.Class
{
    public class StorableDetector : DetectorBase
    {
        protected override void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out IStorable storable))
            {
                OnDetectSomething?.Invoke(storable);
            }
        }
    }
}