namespace LocomotionSystem.Base
{
    public interface IRotatable
    {
        public bool CanRotate();
        public bool ShouldRotate { get; }
        public abstract void StartRotation();
        public abstract void ProcessRotation();
        public abstract void StopRotation();
    }
}