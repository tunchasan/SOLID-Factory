using InputControllerSystem.Settings;
using PlayerSystem;
using TankSystem;
using Zenject;

namespace InstallerSystem
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var inputController = Container.InstantiatePrefabResource("SettingsPresets/InputSettings").GetComponent<InputControllerSettingsBase>();
            Container.BindInstance(inputController.Controller).AsSingle();
            
            Container.Bind<TankData>().FromScriptableObjectResource("TankPresets/Data/StableTank").WhenInjectedInto<StableTank>();
            Container.Bind<TankData>().FromScriptableObjectResource("TankPresets/Data/DynamicTank").WhenInjectedInto<DynamicTank>();
            
            var playerAssetData = Container.InstantiateScriptableObjectResource<PlayerAssetData>("PlayerPresets/PlayerAsset");
            Container.Bind<PlayerAssetData>().FromInstance(playerAssetData);
            var player = Container.InstantiatePrefabResource("PlayerPresets/Player").transform;
            Container.InstantiatePrefab(playerAssetData.item).transform.SetParent(player);
            
            Container.InstantiatePrefabResource("EnvironmentPresets/Environments");
        }
    }
}