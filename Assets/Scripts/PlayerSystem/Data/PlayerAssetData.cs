using TankSystem.Base;
using UnityEngine;

namespace PlayerSystem.Data
{
    [CreateAssetMenu]
    public class PlayerAssetData : ScriptableObject
    {
        public string nickname = string.Empty;
        public GameObject player = null;
        public TankBase item = null;
    }
}