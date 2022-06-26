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
            if (col.gameObject.TryGetStorable(out var storable))
            {
                OnDetectionSomething?.Invoke(storable);
                DetectionState = storable;
            }
        }
        protected override void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.TryGetStorable(out var storable))
            {
                OnDetectionSomething?.Invoke(storable);
                DetectionState = storable;
            }
        }
        protected override void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.TryGetStorable(out var storable))
            {
                DetectionState = null;
            }
        }
    }
}