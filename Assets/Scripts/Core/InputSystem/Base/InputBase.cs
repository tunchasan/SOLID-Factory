using UnityEngine;

namespace Factorio.Core.InputSystem.Base
{
    public abstract class InputBase : MonoBehaviour
    {
        public Vector2 Direction { get; protected set; }
        protected abstract void ProcessInput();
    }
}