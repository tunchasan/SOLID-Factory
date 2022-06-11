using InputControllerSystem.Base;
using LocomotionSystem.Base;
using UnityEngine;
using Zenject;

namespace LocomotionSystem.Class
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MobileLocomotion : LocomotionBase, IMovable, IRotatable
    {
        protected override InputController Input { get; set; }

        [Inject]
        public override void Initialize(InputController input)
        {
            base.Initialize(input);
            _rigidbody2D = GetComponent<Rigidbody2D>();
            StartMovement();
            StartRotation();
        }
        private void FixedUpdate()
        {
            ProcessMovement();
            ProcessRotation();
        }

        #region Movement

        private Rigidbody2D _rigidbody2D = null;
        public bool CanMove { get; private set; }
        public void StartMovement()
        {
            CanMove = true;
        }
        public void ProcessMovement()
        {
            if (CanMove)
            {
                _rigidbody2D.velocity = Input.MovementInput * (100F * Time.fixedDeltaTime);
                OnLocomotion?.Invoke();
            }
            else
                OnCancelledLocomotion?.Invoke();
        }
        public void StopMovement()
        {
            CanMove = false;
        }

        #endregion

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
                OnLocomotion?.Invoke();
            }
            else
                OnCancelledLocomotion?.Invoke();
        }
        public void StopRotation()
        {
            CanRotate = false;
        }

        #endregion
    }
}