using UnityEngine;
using Zenject;

namespace PlayerSystem
{
    public class Player : MonoBehaviour, IPlayer
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