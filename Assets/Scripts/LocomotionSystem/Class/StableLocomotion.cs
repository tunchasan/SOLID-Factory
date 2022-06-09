using InputControllerSystem.Base;
using LocomotionSystem.Base;
using UnityEngine;
using Zenject;

namespace LocomotionSystem.Class
{
    public class StableLocomotion : LocomotionBase, IRotatable
    {
        protected override InputController Input { get; set; }

        [Inject]
        public override void Initialize(InputController input)
        {
            base.Initialize(input);
            StartRotation();
        }
        private void Update()
        {
            ProcessRotation();
        }

        #region Rotation
        public bool CanRotate { get; private set; }
        public void StartRotation()
        {
            CanRotate = true;
        }
        public void ProcessRotation()
        {
            if (CanRotate)
            {
                var angle = Mathf.Atan2(Input.RotationInput.y, Input.RotationInput.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
        
        public void StopRotation()
        {
            CanRotate = false;
        }
        
        #endregion
    }
}