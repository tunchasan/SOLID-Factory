using System;
using InputControllerSystem.Enums;
using InputControllerSystem.Gamepad;
using InputControllerSystem.KeyboardMouse;
using UnityEngine;

namespace InputControllerSystem.Settings
{
    public abstract class InputControllerSettingsBase : MonoBehaviour
    {
        [SerializeField] private ControllerType controllerType;

        private void Awake()
        {
            InitializeController();
        }
        
        private void InitializeController()
        {
            switch (controllerType)
            {
                case ControllerType.Gamepad:
                    gameObject.AddComponent<GamepadController>();
                    break;
                case ControllerType.KeyboardMouse:
                    gameObject.AddComponent<KeyboardMouseController>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}