using System;
using SourceSystem.Class.Detectable.Base;
using UnityEngine;

namespace DetectorSystem.Base
{
    [RequireComponent(typeof(Collider2D), 
        typeof(Rigidbody2D))]
    public abstract class DetectorBase<T>: MonoBehaviour
    where T: IDetectable
    {
        public Action<T> OnDetectionSomething;
        public abstract T DetectionState { protected set; get; }
        protected abstract void OnTriggerEnter2D(Collider2D col);
        protected abstract void OnTriggerStay2D(Collider2D other);
        protected abstract void OnTriggerExit2D(Collider2D col);
    }
}