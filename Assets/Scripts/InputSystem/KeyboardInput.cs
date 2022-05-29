using UnityEngine;

namespace InputSystem
{
    public class KeyboardInput : Input, IEditableInput
    {
        public bool IsActivated { get; private set; } = false;

        #region Private Fields

        private float _horizontalAxis = 0F;
        private float _verticalAxis = 0F;

        #endregion
        
        private void Update()
        {
            if (IsActivated)
            {
                _horizontalAxis = UnityEngine.Input.GetAxis("Horizontal");
                _verticalAxis = UnityEngine.Input.GetAxis("Vertical");
            }
            
            else
            {
                _horizontalAxis = 0F;
                _verticalAxis = 0F;
            }
        }
        
        public void Activate()
        {
            IsActivated = true;
        }

        public void Deactivate()
        {
            IsActivated = false;
        }

        public override Vector2 Direction()
        {
            return new Vector2(_horizontalAxis, _verticalAxis);
        }
    }
}