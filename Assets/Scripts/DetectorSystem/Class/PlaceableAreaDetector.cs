using AreaSystem.Class.PlaceArea;
using DetectorSystem.Base;
using UnityEngine;

namespace DetectorSystem.Class
{
    public class PlaceableAreaDetector : DetectorBase<IPlaceableArea>
    {
        public override IPlaceableArea DetectionState { get; protected set; }

        protected override void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out IPlaceableArea placeableArea))
            {
                OnDetectionSomething?.Invoke(placeableArea);
                DetectionState = placeableArea;
            }
        }

        protected override void OnTriggerStay2D(Collider2D other)
        {
            if (other.TryGetComponent(out IPlaceableArea placeableArea))
            {
                OnDetectionSomething?.Invoke(placeableArea);
                DetectionState = placeableArea;
            }
        }

        protected override void OnTriggerExit2D(Collider2D col)
        {
            if (col.TryGetComponent(out IPlaceableArea placeableArea))
            {
                DetectionState = null;
            }
        }
    }
}