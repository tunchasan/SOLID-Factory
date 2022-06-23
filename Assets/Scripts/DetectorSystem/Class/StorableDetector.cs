using DetectorSystem.Base;
using SourceSystem.Base;
using StorageSystem.Base;
using UnityEngine;

namespace DetectorSystem.Class
{
    public class StorableDetector : DetectorBase<IStorable>
    {
        public override IStorable DetectionState { get; protected set; }
        private static IStorable ValidateDetection(Component target)
        {
            return target.TryGetComponent(out ISource source) ? 
                source.IsStorable(): 
                target.GetComponent<IStorable>();
        }
        protected override void OnTriggerEnter2D(Collider2D col)
        {
            //var storable = ValidateDetection(col);

            if (col.TryGetComponent(out IStorable storable))
            {
                
            }
            
            if (storable != null)
            {
                OnDetectionSomething?.Invoke(storable);
                DetectionState = storable;
            }
        }
        protected override void OnTriggerStay2D(Collider2D other)
        {
            var storable = ValidateDetection(other);
            
            if (storable != null)
            {
                OnDetectionSomething?.Invoke(storable);
                DetectionState = storable;
            }
        }
        protected override void OnTriggerExit2D(Collider2D col)
        {
            var storable = ValidateDetection(col);
            
            if (storable != null)
            {
                DetectionState = null;
            }
        }
    }
}