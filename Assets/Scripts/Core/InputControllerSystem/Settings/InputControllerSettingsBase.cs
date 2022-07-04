using System;
using Factorio.Core.InputControllerSystem.Base;
using Factorio.Core.InputControllerSystem.Enums;
using Factorio.Core.InputControllerSystem.Gamepad;
using Factorio.Core.InputControllerSystem.KeyboardMouse;
using UnityEngine;
using Zenject;

namespace Factorio.Core.InputControllerSystem.Settings
{
    public abstract class InputControllerSettingsBase : MonoBehaviour
    {
        [SerializeField] private ControllerType controllerType;

        public InputController Controller { get; private set; } = null;

        [Inject]
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