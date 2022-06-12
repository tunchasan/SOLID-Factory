namespace LocomotionSystem.Base
{
    public interface IMovable
    {
        public bool CanMove();
        public bool ShouldMove { get; }
        public abstract void StartMovement();
        public abstract void ProcessMovement();
        public abstract void StopMovement();
    }
}