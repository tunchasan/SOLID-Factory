using DetectorSystem.Base;
using UnityEngine;

namespace DetectorSystem.Class
{
    public class Detector : DetectorBase<IDetectable>
    {
        public override IDetectable DetectionState { get; protected set; }

        protected override void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out IDetectable detectable))
            {
                OnDetectionSomething?.Invoke(detectable);
                DetectionState = detectable;
            }
        }

        protected override void OnTriggerExit2D(Collider2D col)
        {
            if (col.TryGetComponent(out IDetectable detectable))
            {
                DetectionState = null;
            }
        }
    }
}