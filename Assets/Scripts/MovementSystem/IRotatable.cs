namespace MovementSystem
{
    public interface IRotatable
    {
        public abstract bool CanRotate();
        public abstract void StartRotation();
        public abstract void ProcessRotation();
        public abstract void StopRotation();
    }
}