using DetectorSystem.Base;
using StorageSystem.Utilities;
using UnityEngine;

namespace StorageSystem.Base
{
    public interface IStorable : IDetectable
    {
        EntityType Type { get; }
        void PossesBy(Transform instigator);
    }
}