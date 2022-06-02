using UnityEngine;

namespace TankSystem
{
    [CreateAssetMenu]
    [System.Serializable]
    public class TankData : ScriptableObject
    {
        public string name = "";
        public TankType type = TankType.StableTank;
    }
}