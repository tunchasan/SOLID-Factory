namespace MovementSystem
{
    public interface IMovable
    {
        public bool CanMove { get; }
        public abstract void StartMovement();
        public abstract void ProcessMovement();
        public abstract void StopMovement();
    }
}