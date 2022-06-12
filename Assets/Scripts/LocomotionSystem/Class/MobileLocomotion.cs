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
        public bool ShouldMove { get; private set; }
        public bool CanMove()
        {
            return ShouldMove && Input.MovementInput.magnitude > 0;
        }
        public void StartMovement()
        {
            ShouldMove = true;
        }
        public void ProcessMovement()
        {
            if (CanMove())
            {
                _rigidbody2D.velocity = Input.MovementInput * (100F * Time.fixedDeltaTime);
                OnLocomotion?.Invoke();
            }
            else
            {
                _rigidbody2D.velocity = Vector2.zero;
                OnCancelledLocomotion?.Invoke();
            }
        }
        public void StopMovement()
        {
            ShouldMove = false;
        }

        #endregion

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
                var angle = Mathf.Atan2(Input.RotationInput.y, Input.RotationInput.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
        public void StopRotation()
        {
            ShouldRotate = false;
        }

        #endregion
    }
}