using InputControllerSystem.Settings;
using UnityEngine;

namespace SettingSystem
{
    public abstract class GameSettingsBase : MonoBehaviour
    {
        public InputControllerSettingsBase InputSettings { get; private set; } = null;

        public void Initialize()
        {
            InputSettings = GetComponent<InputControllerSettings>();
            
            if (InputSettings == null)
            {
                InputSettings = gameObject.AddComponent<InputControllerSettings>();
            }
            
            InputSettings.Initialize();
        }
    }
}