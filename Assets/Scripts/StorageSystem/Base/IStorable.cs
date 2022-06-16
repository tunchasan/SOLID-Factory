using DetectorSystem.Base;
using StorageSystem.Utilities;
using UnityEngine;

namespace StorageSystem.Base
{
    public interface IStorable : IDetectable
    {
        bool Status { get; }
        EntityType Type { get; }
        void PossesBy(Transform instigator);
    }
}