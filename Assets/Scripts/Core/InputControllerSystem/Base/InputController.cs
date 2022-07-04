using UnityEngine;

namespace Factorio.Core.InputControllerSystem.Base
{
    public abstract class InputController : MonoBehaviour
    {
        public Vector2 MovementInput { get; protected set; }
        public Vector2 RotationInput { get; protected set; }
    }
}