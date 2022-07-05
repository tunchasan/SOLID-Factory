using System.Collections;
using Factorio.Simulation.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Factorio.Simulation.Managers
{
    public class SimulationTracker : Singleton<SimulationTracker>
    {
        [SerializeField] private bool isLoop = false;
        [SerializeField] private int simulationIndex = 1;
        [SerializeField] private float simulationDuration = 10F;

        private void Start()
        {
            StartCoroutine(ValidateSimulation());
        }


        private IEnumerator ValidateSimulation()
        {
            if(isLoop) yield break;

            yield return new WaitForSeconds(simulationDuration);
            SceneManager.UnloadSceneAsync(simulationIndex);
            SceneManager.LoadSceneAsync(simulationIndex, LoadSceneMode.Additive);
        }
    }
}