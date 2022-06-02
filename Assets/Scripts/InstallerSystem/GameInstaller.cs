using InputControllerSystem.Base;
using InputControllerSystem.Settings;
using UnityEngine;
using Zenject;

namespace InstallerSystem
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private InputControllerSettingsBase inputSetting = null;
        
        public override void InstallBindings()
        {
            inputSetting.Initialize();
            Container.Bind<InputController>().FromInstance(inputSetting.Controller).AsSingle().NonLazy();
        }
    }
}