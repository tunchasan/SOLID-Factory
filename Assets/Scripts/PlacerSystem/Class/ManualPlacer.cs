using PlacerSystem.Base;
using UnityEngine;

namespace PlacerSystem.Class
{
    public class ManualPlacer : PlacerBase
    {
        protected override bool CanPlace()
        {
            if (HasBlocked)
            {
                Debug.LogWarning(($"Place process has blocked in {name}"));

                return false;
            }

            if (placeableAreaDetector.DetectionState == null)
            {
                Debug.LogWarning(($"{name} didn't detect any IPlaceable area!"));
                
                return false;
            }
            
            return Input.GetKey(KeyCode.Space);
        }
    }
}