using System.Collections;
using Factorio.Core.DetectorSystem.Base;
using Factorio.Core.SourceSystem.Class;
using Factorio.Core.SourceSystem.Class.Detectable.Base;
using UnityEngine;

namespace Factorio.Core.DetectorSystem.Class
{
    public class Detector : DetectorBase<IDetectable>
    {
        public override IDetectable DetectionState { get; protected set; }

        protected override void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.TryGetDetectable(out var detectable))
            {
                BroadcastMessage = StartCoroutine(BroadcastDetectionState());
                OnDetectionSomething?.Invoke(detectable);
                DetectionState = detectable;
            }
        }
        
        protected override IEnumerator BroadcastDetectionState()
        {
            while (true)
            {
                yield return new WaitForSeconds(.25F);
                
                OnDetectionSomething?.Invoke(DetectionState);
            }
        }
        
        protected override void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.TryGetDetectable(out var detectable))
            {
                DetectionState = null;
                StopCoroutine(BroadcastMessage);
            }
        }
    }
}