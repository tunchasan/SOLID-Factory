using UnityEngine;
using Zenject;

namespace Factorio.Simulation.InstallerSystem
{
    public class SimulationInstallerScene3 : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInstance(Camera.main).AsSingle();
        }
    }
}