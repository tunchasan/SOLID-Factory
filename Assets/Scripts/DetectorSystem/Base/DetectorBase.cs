using System;
using UnityEngine;

namespace DetectorSystem
{
    [RequireComponent(typeof(CircleCollider2D), 
        typeof(Rigidbody2D))]
    public abstract class DetectorBase : MonoBehaviour
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