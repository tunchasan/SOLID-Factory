using DetectorSystem.Base;
using StorageSystem.Utilities;
using UnityEngine;

namespace StorageSystem.Base
{
    public interface IStorable : IDetectable
    {
        StorageType Type { get; }
        void PossesBy(Transform instigator);
    }
}