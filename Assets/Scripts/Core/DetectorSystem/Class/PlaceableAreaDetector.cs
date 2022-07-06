using System.Collections;
using Factorio.Core.AreaSystem.Class.PlaceArea.Base;
using Factorio.Core.DetectorSystem.Base;
using UnityEngine;

namespace Factorio.Core.DetectorSystem.Class
{
    public class PlaceableAreaDetector : DetectorBase<IPlaceableArea>
    {
        public override IPlaceableArea DetectionState { get; protected set; }
        protected override void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out IPlaceableArea placeableArea))
            {
                BroadcastMessage = StartCoroutine(BroadcastDetectionState());
                OnDetectionSomething?.Invoke(placeableArea);
                DetectionState = placeableArea;
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
            if (col.TryGetComponent(out IPlaceableArea placeableArea))
            {
                DetectionState = null;
                StopCoroutine(BroadcastMessage);
            }
        }
    }
}