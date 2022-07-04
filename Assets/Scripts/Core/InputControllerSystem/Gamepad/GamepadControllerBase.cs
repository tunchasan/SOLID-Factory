using Factorio.Core.InputControllerSystem.Base;
using Factorio.Core.InputSystem.Base;
using Factorio.Core.InputSystem.Class;

namespace Factorio.Core.InputControllerSystem.Gamepad
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