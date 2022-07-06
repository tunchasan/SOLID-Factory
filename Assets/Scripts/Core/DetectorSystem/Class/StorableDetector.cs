using System.Collections;
using Factorio.Core.DetectorSystem.Base;
using Factorio.Core.SourceSystem.Class;
using Factorio.Core.SourceSystem.Class.Storable.Base;
using UnityEngine;

namespace Factorio.Core.DetectorSystem.Class
{
    public class StorableDetector : DetectorBase<IStorable>
    {
        public override IStorable DetectionState { get; protected set; }

        protected override void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.TryGetStorable(out var storable))
            {
                BroadcastMessage = StartCoroutine(BroadcastDetectionState());
                OnDetectionSomething?.Invoke(storable);
                DetectionState = storable;
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
            if (col.gameObject.TryGetStorable(out var storable))
            {
                DetectionState = null;
                StopCoroutine(BroadcastMessage);
            }
        }
    }
}