using InputControllerSystem.Base;
using MovementSystem;
using UnityEngine;
using Zenject;

namespace Characters
{
    public class TankLocomotion : Locomotion, IMovable, IRotatable
    {
        private Rigidbody2D _rigidbody2D = null;
        private InputController _input = null;
        
        [Inject]
        public void Initialize(InputController input)
        {
            _input = input;
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
        public bool CanMove { get; private set; }
        public void StartMovement()
        {
            CanMove = true;
        }
        public void ProcessMovement()
        {
            if (CanMove)
            {
                _rigidbody2D.velocity = _input.MovementInput * (100F * Time.fixedDeltaTime);
            }
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
                var angle = Mathf.Atan2(_input.RotationInput.y, _input.RotationInput.x) * Mathf.Rad2Deg;
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