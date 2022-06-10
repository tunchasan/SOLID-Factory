using System;
using UnityEngine;

namespace DetectorSystem.Base
{
    [RequireComponent(typeof(CircleCollider2D), 
        typeof(Rigidbody2D))]
    public abstract class DetectorBase<T>: MonoBehaviour
    where T: IDetectable
    {
        public Action<T> OnDetectSomething;
        
        protected abstract void OnTriggerEnter2D(Collider2D col);
    }
}