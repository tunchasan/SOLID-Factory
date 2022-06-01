using InputControllerSystem.Base;
using MovementSystem;
using UnityEngine;

namespace Characters
{
    public class TankLocomotion : Locomotion, IMovable, IRotatable
    {
        private Rigidbody2D _rigidbody2D = null;
        
        private void Awake()
        {
            inputController = GetComponent<InputController>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
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
                _rigidbody2D.velocity = inputController.MovementInput * (100F * Time.fixedDeltaTime);
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
            var angle = Mathf.Atan2(inputController.RotationInput.y, inputController.RotationInput.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        public void StopRotation()
        {
            _shouldRotate = false;
        }

        #endregion
    }
}