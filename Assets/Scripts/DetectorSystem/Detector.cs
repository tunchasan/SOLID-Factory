using System;
using UnityEngine;

namespace DetectorSystem
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class Detector : MonoBehaviour, IDetector
    {
        public Action<IDetectable> OnDetectSomething;

        public void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDetectable target))
            {
                OnDetectSomething?.Invoke(target);
            }
        }
    }
}