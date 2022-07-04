using Factorio.Core.DetectorSystem.Base;
using Factorio.Core.SourceSystem.Base;
using Factorio.Core.SourceSystem.Class.Detectable.Base;
using UnityEngine;

namespace Factorio.Core.DetectorSystem.Class
{
    public class Detector : DetectorBase<IDetectable>
    {
        public override IDetectable DetectionState { get; protected set; }
        private static IDetectable ValidateDetection(Component target)
        {
            return target.TryGetComponent(out SourceBase source) ? 
                source.IsStorable() : 
                target.GetComponent<IDetectable>();
        }
        protected override void OnTriggerEnter2D(Collider2D col)
        {
            var detectable = ValidateDetection(col);
            
            if (detectable != null)
            {
                OnDetectionSomething?.Invoke(detectable);
                DetectionState = detectable;
            }
        }
        protected override void OnTriggerStay2D(Collider2D other)
        {
            var detectable = ValidateDetection(other);
            
            if (detectable != null)
            {
                OnDetectionSomething?.Invoke(detectable);
                DetectionState = detectable;
            }
        }
        protected override void OnTriggerExit2D(Collider2D col)
        {
            var detectable = ValidateDetection(col);
            
            if (detectable != null)
            {
                DetectionState = null;
            }
        }
    }
}