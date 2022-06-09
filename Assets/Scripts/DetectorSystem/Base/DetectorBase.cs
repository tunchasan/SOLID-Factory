using System;
using UnityEngine;

namespace DetectorSystem.Base
{
    [RequireComponent(typeof(CircleCollider2D), 
        typeof(Rigidbody2D))]
    public abstract class DetectorBase : MonoBehaviour
    {
        public Action<IDetectable> OnDetectSomething;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out IDetectable target))
            {
                OnDetectSomething?.Invoke(target);
            }
        }
    }
}