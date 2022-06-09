using InputSystem.Base;
using UnityEngine;

namespace InputSystem.Class
{
    public class JoystickInput : InputBase
    {
        private void Update()
        {
            ProcessInput();
        }

        protected override void ProcessInput()
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            var verticalInput = Input.GetAxis("Vertical");
            var current = Direction;
            var target = new Vector2(horizontalInput, verticalInput);
            Direction = Vector2.Lerp(current, target, Time.deltaTime * 5F);
        }
    }
}