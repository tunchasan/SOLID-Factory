using InputSystem.Base;
using UnityEngine;

namespace InputSystem.Class
{
    public class MouseInput : InputBase
    {
        private void Update()
        {
            ProcessInput();
        }
        
        protected override void ProcessInput()
        {
            var mainCamera = Camera.main;
            if(mainCamera == null) return;
            Direction = Input.mousePosition;
        }
    }
}