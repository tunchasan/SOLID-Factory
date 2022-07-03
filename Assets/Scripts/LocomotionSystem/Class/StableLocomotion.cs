using InputControllerSystem.Base;
using LocomotionSystem.Base;
using UnityEngine;
using Zenject;

namespace LocomotionSystem.Class
{
    public class StableLocomotion : LocomotionBase, IRotatable
    {
        protected override InputController Input { get; set; }

        [Inject] protected Camera Camera { get; set; } = null;

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
        
        public bool ShouldRotate { get; private set; }
        public bool CanRotate()
        {
            return ShouldRotate && Input.RotationInput.magnitude > 0;
        }
        public void StartRotation()
        {
            ShouldRotate = true;
        }
        public void ProcessRotation()
        {
            if (CanRotate())
            {
                var difference = Camera.ScreenToWorldPoint(Input.RotationInput) - transform.position;
                difference.Normalize();
                var rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, rotationZ - 0F);
            }
        }
        public void StopRotation()
        {
            ShouldRotate = false;
        }
        
        #endregion
    }
}