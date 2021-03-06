using Factorio.Core.InputControllerSystem.Settings;
using Factorio.Core.PlayerSystem.Data;
using Factorio.Core.TankSystem.Class;
using Factorio.Core.TankSystem.Data;
using UnityEngine;
using Zenject;

namespace Factorio.Core.InstallerSystem.Class
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInstance(Camera.main).AsSingle();
            var inputController = Container.InstantiatePrefabResource("SettingsPresets/InputSettings").GetComponent<InputControllerSettingsBase>();
            Container.BindInstance(inputController.Controller).AsSingle();
            Container.Bind<TankData>().FromScriptableObjectResource("TankPresets/Data/StableTank").WhenInjectedInto<StableTank>();
            Container.Bind<TankData>().FromScriptableObjectResource("TankPresets/Data/MobileTank").WhenInjectedInto<MobileTank>();
            Container.Bind<TankData>().FromScriptableObjectResource("TankPresets/Data/HeavyTank").WhenInjectedInto<HeavyTank>();
            
            var playerAssetData = Container.InstantiateScriptableObjectResource<PlayerAssetData>("PlayerPresets/PlayerAsset");
            Container.Bind<PlayerAssetData>().FromInstance(playerAssetData);
        }
    }
}