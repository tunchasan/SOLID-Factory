using Factorio.Core.InputControllerSystem.Base;
using Factorio.Core.TankSystem.Data;
using Factorio.Simulation.LocomotionSystem;
using UnityEngine;
using Zenject;

namespace Factorio.Simulation.InstallerSystem
{
    public class SimulationInstallerScene2 : MonoInstaller
    {
        [SerializeField] private InputController simulationInputController = null;
        
        public override void InstallBindings()
        {
            Container.BindInstance(Camera.main).AsSingle();
            Container.BindInstance(simulationInputController).AsSingle();
            Container.Bind<TankData>().FromScriptableObjectResource("TankPresets/Data/MobileTank").WhenInjectedInto<MobileTankSimulation>();
        }
    }
}