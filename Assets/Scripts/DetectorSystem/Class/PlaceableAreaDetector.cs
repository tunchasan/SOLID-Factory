using AreaSystem.Class.PlaceArea;
using DetectorSystem.Base;
using UnityEngine;

namespace DetectorSystem.Class
{
    public class PlaceableAreaDetector : DetectorBase<IPlaceableArea>
    {
        protected override void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out IPlaceableArea area))
            {
                OnDetectSomething?.Invoke(area);
            }
        }
    }
}