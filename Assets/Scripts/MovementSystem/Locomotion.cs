using InputSystem;
using UnityEngine;

namespace MovementSystem
{
    public abstract class Locomotion : MonoBehaviour
    {
        protected IInput input = null;
    }
}