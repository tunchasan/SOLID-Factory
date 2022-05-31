using UnityEngine;

namespace InputSystem
{
    public abstract class Input : MonoBehaviour
    {
        public Vector2 Direction { get; protected set; }
        protected abstract void ProcessInput();
    }
}