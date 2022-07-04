using Factorio.Core.PlayerSystem.Data;
using UnityEngine;
using Zenject;

namespace Factorio.Core.PlayerSystem.Base
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