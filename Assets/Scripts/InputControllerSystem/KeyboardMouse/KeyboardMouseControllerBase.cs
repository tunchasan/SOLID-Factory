using InputControllerSystem.Base;
using InputSystem;
using InputSystem.Base;
using InputSystem.Class;

namespace InputControllerSystem.KeyboardMouse
{
    public abstract class KeyboardMouseControllerBase : InputController
    {
        private InputBase _mouseInput = null;
        private InputBase _keyboardInput = null;
 
        private void Awake()
        {
            _mouseInput = gameObject.AddComponent<MouseInput>();
            _keyboardInput = gameObject.AddComponent<KeyboardInput>();
        }
 
        private void Update()
        {
            MovementInput = _keyboardInput.Direction;
            RotationInput = _mouseInput.Direction;
        }
    }
}