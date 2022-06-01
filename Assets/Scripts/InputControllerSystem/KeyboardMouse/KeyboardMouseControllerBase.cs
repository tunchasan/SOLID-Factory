using InputControllerSystem.Base;
using InputSystem;

namespace InputControllerSystem.KeyboardMouse
{
    public abstract class KeyboardMouseControllerBase : InputController
    {
        private Input _mouseInput = null;
        private Input _keyboardInput = null;
 
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