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
            var mousePosition = Input.mousePosition;
            Direction = new Vector3(mousePosition.x, mousePosition.y) - 
                        mainCamera.WorldToScreenPoint(transform.position);
        }
    }
}