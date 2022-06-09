using InputControllerSystem.Base;
using InputSystem;
using InputSystem.Base;
using InputSystem.Class;

namespace InputControllerSystem.Gamepad
 {
     public abstract class GamepadControllerBase : InputController
     {
         private InputBase _gamepadInput = null;
 
         private void Awake()
         {
             _gamepadInput = gameObject.AddComponent<JoystickInput>();
         }
 
         private void Update()
         {
             MovementInput = _gamepadInput.Direction;
             RotationInput = _gamepadInput.Direction;
         }
     }
 }