using TankSystem.Utilities;
using UnityEngine;

namespace TankSystem.Data
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