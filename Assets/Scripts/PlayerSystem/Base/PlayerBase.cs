using PlayerSystem.Data;
using UnityEngine;
using Zenject;

namespace PlayerSystem.Base
{
    public abstract class PlayerBase : MonoBehaviour
    {
        public PlayerAssetData Asset { get; private set; }

        [Inject]
        private void Initialize(PlayerAssetData data)
        {
            Asset = data;
            name = Asset.nickname;
        }
    }
}