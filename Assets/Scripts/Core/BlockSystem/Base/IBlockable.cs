namespace Factorio.Core.BlockSystem.Base
{
    public interface IBlockable
    {
        bool HasBlocked { get; }
        void Block();
        void UnBlock();
    }
}