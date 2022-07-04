using Factorio.Core.InputControllerSystem.Base;
using Factorio.Core.InputSystem.Base;
using Factorio.Core.InputSystem.Class;

namespace Factorio.Core.InputControllerSystem.KeyboardMouse
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