using DetectorSystem.Base;
using StorageSystem.Base;
using UnityEngine;

namespace DetectorSystem.Class
{
    public class StorableDetector : DetectorBase<IStorable>
    {
        public override IStorable DetectionState { get; protected set; }

        protected override void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out IStorable storable))
            {
                OnDetectionSomething?.Invoke(storable);
                DetectionState = storable;
            }
        }

        protected override void OnTriggerExit2D(Collider2D col)
        {
            if (col.TryGetComponent(out IStorable storable))
            {
                DetectionState = null;
            }
        }
    }
}