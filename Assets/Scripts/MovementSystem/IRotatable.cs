namespace MovementSystem
{
    public interface IRotatable
    {
        public abstract bool CanRotate();
        public abstract bool IsRotating();
        public abstract void StartRotation();
        public abstract void ProcessRotation();
        public abstract void StopRotation();
    }
}