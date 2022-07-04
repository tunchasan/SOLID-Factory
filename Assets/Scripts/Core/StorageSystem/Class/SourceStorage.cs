using Factorio.Core.StorageSystem.Base;
using Factorio.Core.StorageSystem.Utilities;

namespace Factorio.Core.StorageSystem.Class
{
    public class SourceStorage : StorageBase
    {
        protected override EntityType Type { get; set; } = EntityType.Source;
    }
}