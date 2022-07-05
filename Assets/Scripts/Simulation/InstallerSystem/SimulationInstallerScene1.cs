using Factorio.Core.InputControllerSystem.Base;
using Factorio.Core.PlayerSystem.Data;
using Factorio.Core.TankSystem.Class;
using Factorio.Core.TankSystem.Data;
using UnityEngine;
using Zenject;

namespace Factorio.Simulation.InstallerSystem
{
    public class SimulationInstallerScene1 : MonoInstaller
    {
        [SerializeField] private InputController simulationInputController = null;
        
        public override void InstallBindings()
        {
            Container.BindInstance(Camera.main).AsSingle();
            Container.BindInstance(simulationInputController).AsSingle();
            Container.Bind<TankData>().FromScriptableObjectResource("TankPresets/Data/StableTank").WhenInjectedInto<StableTank>();
            
            var playerAssetData = Container.InstantiateScriptableObjectResource<PlayerAssetData>("PlayerPresets/PlayerAsset");
            Container.Bind<PlayerAssetData>().FromInstance(playerAssetData);
        }
    }
}