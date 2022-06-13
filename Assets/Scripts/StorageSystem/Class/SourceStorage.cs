using StorageSystem.Base;
using StorageSystem.Utilities;

namespace StorageSystem.Class
{
    public class SourceStorage : StorageBase
    {
        protected override EntityType Type { get; set; } = EntityType.Source;
    }
}