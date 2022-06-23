namespace NodeSystem
{
    public interface INode
    {
        INode NextNode { get; }
        void Input();
        void Process();
        void Output();
        void ValidateNode(INode nextNode);
    }
}