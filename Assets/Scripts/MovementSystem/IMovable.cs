namespace MovementSystem
{
    public interface IMovable
    {
        public abstract bool CanMove();
        public abstract void StartMovement();
        public abstract void ProcessMovement();
        public abstract void StopMovement();
    }
}