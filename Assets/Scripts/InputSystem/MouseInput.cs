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
            var mainCamera = Camera.main;
            if(mainCamera == null) return;
            var mousePosition = UnityEngine.Input.mousePosition;
            Direction = new Vector3(mousePosition.x, mousePosition.y) - 
                        mainCamera.WorldToScreenPoint(transform.position);
        }
    }
}