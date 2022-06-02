using TankSystem;
using UnityEngine;

namespace PlayerSystem
{
    [CreateAssetMenu]
    public class PlayerAssetData : ScriptableObject
    {
        public string nickname = "";
        public GameObject player = null;
        public Tank item = null;
    }
}