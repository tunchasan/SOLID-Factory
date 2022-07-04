using Factorio.Core.InputSystem.Base;
using UnityEngine;

namespace Factorio.Core.InputSystem.Class
{
    public class KeyboardInput : InputBase
    {
        private void Update()
        {
            ProcessInput();
        }

        protected override void ProcessInput()
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            var verticalInput = Input.GetAxis("Vertical");
            Direction = new Vector2(horizontalInput, verticalInput);
        }
    }
}