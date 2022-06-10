using DetectorSystem.Base;
using UnityEngine;

namespace DetectorSystem.Class
{
    public class Detector : DetectorBase
    {
        protected override void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out IDetectable target))
            {
                OnDetectSomething?.Invoke(target);
            }
        }
    }
}