using InputSystem;
using MovementSystem;
using UnityEngine;

namespace Characters
{
    public class TankLocomotion : Locomotion, IMovable, IRotatable
    {
        private void Awake()
        {
            input = GetComponent<IInput>();
        }

        private void Start()
        {
            StartMovement();
            StartRotation();
        }

        private void Update()
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
                var velocity = input.Direction() * (Time.deltaTime * 5F);

                transform.position += (Vector3) velocity;
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
            if (CanRotate())
            {
                var currentRotation = transform.eulerAngles;
                
                var targetRotation = Quaternion.Euler(new Vector3(0, 
                    0, Mathf.Atan2(input.Direction().y, input.Direction().x) * 180 / Mathf.PI));

                transform.eulerAngles = Vector3.Lerp(currentRotation, 
                    targetRotation.eulerAngles, Time.deltaTime * 5F);
            }
        }

        public void StopRotation()
        {
            _shouldRotate = false;
        }

        #endregion
    }
}