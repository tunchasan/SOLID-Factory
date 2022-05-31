using UnityEngine;

namespace InputSystem
{
    public class MouseInput : Input
    {
        private void Update()
        {
            ProcessInput();
        }
        
        protected override void ProcessInput()
        {
            var horizontalInput = UnityEngine.Input.GetAxis("Mouse X");
            var verticalInput = UnityEngine.Input.GetAxis("Mouse Y");
            Direction = new Vector2(horizontalInput, verticalInput).normalized;
        }
    }
}