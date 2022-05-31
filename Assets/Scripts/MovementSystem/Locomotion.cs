using UnityEngine;
using Input = InputSystem.Input;

namespace MovementSystem
{
    public abstract class Locomotion : MonoBehaviour
    {
        protected Input input = null;
    }
}