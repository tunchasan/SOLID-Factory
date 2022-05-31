using UnityEngine;

namespace InputSystem
{
    public class KeyboardInput : Input
    {
        private void Update()
        {
            ProcessInput();
        }

        protected override void ProcessInput()
        {
            var horizontalInput = UnityEngine.Input.GetAxis("Horizontal");
            var verticalInput = UnityEngine.Input.GetAxis("Vertical");
            Direction = new Vector2(horizontalInput, verticalInput);
        }
    }
}