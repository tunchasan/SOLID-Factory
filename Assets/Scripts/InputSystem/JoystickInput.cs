using UnityEngine;

namespace InputSystem
{
    public class JoystickInput : Input
    {
        private void Update()
        {
            ProcessInput();
        }

        protected override void ProcessInput()
        {
            var horizontalInput = UnityEngine.Input.GetAxis("Horizontal");
            var verticalInput = UnityEngine.Input.GetAxis("Vertical");
            var current = Direction;
            var target = new Vector2(horizontalInput, verticalInput);
            Direction = Vector2.Lerp(current, target, Time.deltaTime * 5F);
        }
    }
}