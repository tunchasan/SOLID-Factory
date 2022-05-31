using UnityEngine;

namespace InputSystem
{
    public interface IInput
    {
        bool IsActivated { get; }
        void Activate();
        void Deactivate();
        Vector2 Direction();
    }
}