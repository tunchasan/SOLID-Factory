using TankSystem;
using TankSystem.Base;
using UnityEngine;

namespace PlayerSystem
{
    [CreateAssetMenu]
    public class PlayerAssetData : ScriptableObject
    {
        public string nickname = "";
        public GameObject player = null;
        public TankBase item = null;
    }
}