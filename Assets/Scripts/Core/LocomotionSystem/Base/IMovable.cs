namespace Factorio.Core.LocomotionSystem.Base
{
    public interface IMovable
    {
        public bool CanMove();
        public bool ShouldMove { get; }
        public float MovementSpeed { get; }
        public void SetMovementSpeed(float speed);
        public abstract void StartMovement();
        public abstract void ProcessMovement();
        public abstract void StopMovement();
    }
}