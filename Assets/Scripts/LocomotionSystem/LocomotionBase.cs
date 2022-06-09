using InputControllerSystem.Base;
using UnityEngine;

namespace LocomotionSystem
{
    public abstract class LocomotionBase : MonoBehaviour
    {
        protected abstract InputController Input { get;  set; }
        
        public virtual void Initialize(InputController input)
        {
            Input = input;
        }
    }
}