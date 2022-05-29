using UnityEngine;

namespace InputSystem
{
    public abstract class Input : MonoBehaviour, IInput
    {
        public abstract Vector2 Direction();
    }
}