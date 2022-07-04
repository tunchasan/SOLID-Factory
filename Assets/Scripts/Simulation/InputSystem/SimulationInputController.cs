using Factorio.Core.InputControllerSystem.Base;
using Factorio.Core.InputSystem.Base;

namespace Factorio.Simulation.InputSystem
{
    public class SimulationInputController : InputController
    {
        private InputBase _simulationMouseInput = null;
        private InputBase _simulationKeyboardInput = null;
 
        private void Awake()
        {
            _simulationMouseInput = GetComponent<SimulationMouseInput>();
            _simulationKeyboardInput = GetComponent<SimulationKeyboardInput>();
        }
 
        private void Update()
        {
            MovementInput = _simulationKeyboardInput.Direction;
            RotationInput = _simulationMouseInput.Direction;
        }
    }
}