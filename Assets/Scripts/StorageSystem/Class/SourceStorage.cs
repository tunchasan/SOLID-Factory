using StorageSystem.Base;
using StorageSystem.Utilities;

namespace StorageSystem.Class
{
    public class SourceStorage : StorageBase
    {
        protected override StorageType Type { get; set; } = StorageType.Source;
    }
}