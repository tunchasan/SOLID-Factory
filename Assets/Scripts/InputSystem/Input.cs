using UnityEngine;

namespace InputSystem
{
    public abstract class Input : MonoBehaviour, IInput
    {
        public void Activate()
        {
            IsActivated = true;
        }

        public void Deactivate()
        {
            IsActivated = false;
        }
        
        public bool IsActivated { get; private set; } = true;

        public abstract Vector2 Direction();

    }
}