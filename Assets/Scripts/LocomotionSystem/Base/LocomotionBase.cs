using System;
using InputControllerSystem.Base;
using UnityEngine;

namespace LocomotionSystem.Base
{
    public abstract class LocomotionBase : MonoBehaviour
    {
        protected abstract InputController Input { get;  set; }
        public Action OnLocomotion { get; set; }
        public Action OnCancelledLocomotion { get; set; }
        public virtual void Initialize(InputController input)
        {
            Input = input;
        }
    }
}