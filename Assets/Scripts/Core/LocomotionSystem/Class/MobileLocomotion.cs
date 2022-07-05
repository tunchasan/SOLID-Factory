using Factorio.Core.InputControllerSystem.Base;
using Factorio.Core.LocomotionSystem.Base;
using UnityEngine;
using Zenject;

namespace Factorio.Core.LocomotionSystem.Class
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MobileLocomotion : LocomotionBase, IMovable, IRotatable
    {
        protected override InputController Input { get; set; }

        [Inject] protected Camera Camera { get; set; } = null;

        [Inject]
        public override void Initialize(InputController input)
        {
            base.Initialize(input);
            _rigidbody2D = GetComponent<Rigidbody2D>();
            StartMovement();
            StartRotation();
        }
        protected virtual void FixedUpdate()
        {
            ProcessMovement();
            ProcessRotation();
        }

        #region Movement

        private Rigidbody2D _rigidbody2D = null;
        public bool ShouldMove { get; private set; }
        public float MovementSpeed { get; private set; } = 1F;
        public void SetMovementSpeed(float speed)
        {
            MovementSpeed = speed;
        }
        public virtual bool CanMove()
        {
            return ShouldMove && Input.MovementInput.magnitude > 0;
        }
        public void StartMovement()
        {
            ShouldMove = true;
        }
        public virtual void ProcessMovement()
        {
            if (CanMove())
            {
                var currentVelocity = _rigidbody2D.velocity;
                var targetVelocity = Input.MovementInput * (MovementSpeed * 2.5F);
                _rigidbody2D.velocity = Vector3.Lerp(currentVelocity, targetVelocity, Time.fixedDeltaTime * 5F);
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