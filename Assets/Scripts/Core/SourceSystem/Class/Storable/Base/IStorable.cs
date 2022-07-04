using Factorio.Core.SourceSystem.Class.Detectable.Base;
using Factorio.Core.StorageSystem.Utilities;
using UnityEngine;

namespace Factorio.Core.SourceSystem.Class.Storable.Base
{
    public interface IStorable : IDetectable
    {
        bool Status { get; }
        EntityType Type { get; }
        void PossesBy(Transform instigator);
    }
}