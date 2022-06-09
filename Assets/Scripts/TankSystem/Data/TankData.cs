using TankSystem.Utilities;
using UnityEngine;

namespace TankSystem.Data
{
    [CreateAssetMenu]
    [System.Serializable]
    public class TankData : ScriptableObject
    {
        public string name = "";
        public TankType type = TankType.Stable;
    }
}