using DetectorSystem.Base;
using StorageSystem.Utilities;
using UnityEngine;

namespace StorageSystem.Base
{
    public interface IStorable : IDetectable
    {
        bool CanStorable { get; }
        StorageType Type { get; }
        void PossesBy(Transform instigator);
    }
}