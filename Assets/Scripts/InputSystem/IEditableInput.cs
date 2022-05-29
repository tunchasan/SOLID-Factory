namespace InputSystem
{
    public interface IEditableInput
    {
        public void Activate();
        public void Deactivate();
        public bool IsActivated { get; }
    }
}