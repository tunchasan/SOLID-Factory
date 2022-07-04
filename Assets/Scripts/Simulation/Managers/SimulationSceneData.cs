using UnityEngine;

namespace Factorio.Simulation.Managers
{
    [System.Serializable]
    public class SimulationSceneData
    {
        public string scene = "";
        public GameObject camera;
        public SimulationUIElement userInterface;
    }
}