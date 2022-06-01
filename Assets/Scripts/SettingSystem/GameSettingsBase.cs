using InputControllerSystem.Settings;
using UnityEngine;

namespace SettingSystem
{
    public abstract class GameSettingsBase : MonoBehaviour
    {
        private static InputControllerSettingsBase _inputSettings = null;

        private void Awake()
        {
            _inputSettings = GetComponent<InputControllerSettings>();
            
            if (_inputSettings == null)
            {
                _inputSettings = gameObject.AddComponent<InputControllerSettings>();
            }
        }
    }
}