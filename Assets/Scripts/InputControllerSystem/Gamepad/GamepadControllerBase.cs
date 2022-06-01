using InputControllerSystem.Base;
using InputSystem;

namespace InputControllerSystem.Gamepad
 {
     public abstract class GamepadControllerBase : InputController
     {
         private Input _gamepadInput = null;
 
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