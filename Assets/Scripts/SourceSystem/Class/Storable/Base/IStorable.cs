using SourceSystem.Class.Detectable.Base;
using StorageSystem.Utilities;
using UnityEngine;

namespace SourceSystem.Class.Storable.Base
{
    public interface IStorable : IDetectable
    {
        bool Status { get; }
        EntityType Type { get; }
        void PossesBy(Transform instigator);
    }
}