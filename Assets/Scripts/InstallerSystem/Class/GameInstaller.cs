using GameEventsSystem;
using InputControllerSystem.Settings;
using PlayerSystem.Data;
using TankSystem.Class;
using TankSystem.Data;
using Zenject;

namespace InstallerSystem.Class
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var gameEvents = Container.InstantiatePrefabResource("GamePresets/GameEvents").GetComponent<GameEvents>();
            Container.Bind<GameEvents>().FromInstance(gameEvents);
            
            var inputController = Container.InstantiatePrefabResource("SettingsPresets/InputSettings").GetComponent<InputControllerSettingsBase>();
            Container.BindInstance(inputController.Controller).AsSingle();
            
            Container.Bind<TankData>().FromScriptableObjectResource("TankPresets/Data/StableTank").WhenInjectedInto<StableTank>();
            Container.Bind<TankData>().FromScriptableObjectResource("TankPresets/Data/MobileTank").WhenInjectedInto<MobileTank>();
            Container.Bind<TankData>().FromScriptableObjectResource("TankPresets/Data/HeavyTank").WhenInjectedInto<HeavyTank>();
            
            var playerAssetData = Container.InstantiateScriptableObjectResource<PlayerAssetData>("PlayerPresets/PlayerAsset");
            Container.Bind<PlayerAssetData>().FromInstance(playerAssetData);
            // var player = Container.InstantiatePrefabResource("PlayerPresets/Player").transform;
            // Container.InstantiatePrefab(playerAssetData.item).transform.SetParent(player);
            
            // Container.InstantiatePrefabResource("EnvironmentPresets/Environments");
        }
    }
}