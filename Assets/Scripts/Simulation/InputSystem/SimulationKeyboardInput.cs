using Factorio.Core.InputSystem.Base;
using UnityEngine;

namespace Factorio.Simulation.InputSystem
{
    public class SimulationKeyboardInput : InputBase
    {
        [SerializeField] private Transform simulationTarget = null;

        private void Update()
        {
            ProcessInput();
        }
        protected override void ProcessInput()
        {
            Direction = simulationTarget.position;
        }
    }
}