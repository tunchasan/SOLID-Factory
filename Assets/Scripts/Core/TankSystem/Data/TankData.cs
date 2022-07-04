using Factorio.Core.TankSystem.Utilities;
using UnityEngine;

namespace Factorio.Core.TankSystem.Data
{
    [CreateAssetMenu]
    [System.Serializable]
    public class TankData : ScriptableObject
    {
        [Header("General")]
        public string name = "";
        public TankType type = TankType.Stable;
        
        [Header("Movement")]
        public float movementSpeed = 5F;
    }
}