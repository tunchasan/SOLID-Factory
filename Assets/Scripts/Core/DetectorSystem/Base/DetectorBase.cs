using System;
using System.Collections;
using Factorio.Core.SourceSystem.Class.Detectable.Base;
using UnityEngine;

namespace Factorio.Core.DetectorSystem.Base
{
    [RequireComponent(typeof(Collider2D), 
        typeof(Rigidbody2D))]
    public abstract class DetectorBase<T>: MonoBehaviour
    where T: IDetectable
    {
        public Action<T> OnDetectionSomething;
        public abstract T DetectionState { protected set; get; }
        protected Coroutine BroadcastMessage { get; set; }
        protected abstract void OnTriggerEnter2D(Collider2D col);
        protected abstract IEnumerator BroadcastDetectionState();
        protected abstract void OnTriggerExit2D(Collider2D col);
    }
}