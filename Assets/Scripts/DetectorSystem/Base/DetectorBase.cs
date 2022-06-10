using System;
using UnityEngine;

namespace DetectorSystem.Base
{
    [RequireComponent(typeof(CircleCollider2D), 
        typeof(Rigidbody2D))]
    public abstract class DetectorBase : MonoBehaviour
    {
        public Action<IDetectable> OnDetectSomething;

        protected abstract void OnTriggerEnter2D(Collider2D col);
    }
}