using InputControllerSystem.Settings;
using UnityEngine;
using Zenject;

namespace InstallerSystem
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var inputController = LoadInputControllerSettings().Controller;
            Container.BindInstance(inputController).AsSingle();
        }

        private InputControllerSettingsBase LoadInputControllerSettings()
        {
            var settings = Instantiate(Resources.Load("InputSettings") as GameObject)
                .GetComponent<InputControllerSettingsBase>();
            settings.Initialize();

            return settings;
        }
    }
}