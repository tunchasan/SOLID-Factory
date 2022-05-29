using InputSystem;
using MovementSystem;

namespace Characters
{
    public class TankLocomotion : Locomotion, IMovable, IRotatable
    {
        private void Awake()
        {
            input = GetComponent<IInput>();
        }

        private void Update()
        {
            // TODO
        }

        public bool CanMove()
        {
            throw new System.NotImplementedException();
        }

        public bool IsMoving()
        {
            throw new System.NotImplementedException();
        }

        public void StartMovement()
        {
            throw new System.NotImplementedException();
        }

        public void ProcessMovement()
        {
            throw new System.NotImplementedException();
        }

        public void StopMovement()
        {
            throw new System.NotImplementedException();
        }

        public bool CanRotate()
        {
            throw new System.NotImplementedException();
        }

        public bool IsRotating()
        {
            throw new System.NotImplementedException();
        }

        public void StartRotation()
        {
            throw new System.NotImplementedException();
        }

        public void ProcessRotation()
        {
            throw new System.NotImplementedException();
        }

        public void StopRotation()
        {
            throw new System.NotImplementedException();
        }
    }
}