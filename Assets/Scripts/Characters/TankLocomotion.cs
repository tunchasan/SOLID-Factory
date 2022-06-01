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
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _input = input;
            
            StartMovement();
            StartRotation();
        }

        private void FixedUpdate()
        {
            ProcessMovement();
            ProcessRotation();
        }

        #region Movement

        private bool _shouldMove = false;
        public bool CanMove()
        {
            return _shouldMove;
        }
        public void StartMovement()
        {
            _shouldMove = true;
        }
        public void ProcessMovement()
        {
            if (CanMove())
            {
                _rigidbody2D.velocity = _input.MovementInput * (100F * Time.fixedDeltaTime);
            }
        }

        public void StopMovement()
        {
            _shouldMove = false;
        }

        #endregion

        #region Rotation

        private bool _shouldRotate = false;
        
        public bool CanRotate()
        {
            return _shouldRotate;
        }

        public void StartRotation()
        {
            _shouldRotate = true;
        }

        public void ProcessRotation()
        {
            var angle = Mathf.Atan2(_input.RotationInput.y, _input.RotationInput.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        public void StopRotation()
        {
            _shouldRotate = false;
        }

        #endregion
    }
}