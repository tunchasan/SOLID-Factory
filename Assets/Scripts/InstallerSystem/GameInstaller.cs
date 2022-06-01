using InputControllerSystem.Base;
using SettingSystem;
using UnityEngine;
using Zenject;

namespace InstallerSystem
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameSettingsBase gameSettings = null;
        
        public override void InstallBindings()
        {
            gameSettings.Initialize();
            Container.Bind<GameSettingsBase>().AsSingle();
            Container.Bind<InputController>().FromInstance(gameSettings.InputSettings.Controller).AsSingle();
        }
    }
}