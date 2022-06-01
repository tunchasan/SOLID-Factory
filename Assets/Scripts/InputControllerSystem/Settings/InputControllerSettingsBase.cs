using System;
using InputControllerSystem.Base;
using InputControllerSystem.Enums;
using InputControllerSystem.Gamepad;
using InputControllerSystem.KeyboardMouse;
using UnityEngine;

namespace InputControllerSystem.Settings
{
    public abstract class InputControllerSettingsBase : MonoBehaviour
    {
        [SerializeField] private ControllerType controllerType;

        public InputController Controller { get; private set; } = null;

        public void Initialize()
        {
            switch (controllerType)
            {
                case ControllerType.Gamepad:
                    Controller = gameObject.AddComponent<GamepadController>();
                    break;
                case ControllerType.KeyboardMouse:
                    Controller = gameObject.AddComponent<KeyboardMouseController>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}