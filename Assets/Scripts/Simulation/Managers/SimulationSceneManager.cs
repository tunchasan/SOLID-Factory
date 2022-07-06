using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Factorio.Simulation.Managers
{
    public class SimulationSceneManager : MonoBehaviour
    {
        [SerializeField] private SimulationSceneData activeScene = new();
        [SerializeField] private List<SimulationSceneData> scenes = new();

        private YieldInstruction _waitSeconds;
        private bool _isProcessing = false;
        
        private const float ProcessDuration = 1F;

        private void Awake()
        {
            _waitSeconds = new WaitForSeconds(ProcessDuration);
        }
        private void Start()
        {
            Debug.unityLogger.logEnabled = false;

            InitializeSimulationScenes();
        }
        private void InitializeSimulationScenes()
        {
            foreach (var scene in scenes)
            {
                SceneManager.LoadSceneAsync(scene.scene, LoadSceneMode.Additive);
            }
        }
        public void SimulateScene(int sceneIndex)
        {
            if(_isProcessing) return;
            if(sceneIndex >= scenes.Count) return;

            _isProcessing = true;
            
            StartCoroutine(Process(scenes[sceneIndex]));
        }
        private IEnumerator Process(SimulationSceneData target)
        {
            var isReverse = false;
            
            if (target.camera.activeInHierarchy)
            {
                target.camera.SetActive(false);
                activeScene.camera.SetActive(true);
                isReverse = true;
            }
            else
                target.camera.SetActive(true);
            
            HandleScenes(target.scene, isReverse);
            
            target.userInterface.Animate(ProcessDuration, isReverse, 
                isReverse ? 0F : .5F);

            yield return _waitSeconds;
            _isProcessing = false;
        }
        private void HandleScenes(string sceneName, bool isReverse)
        {
            if (!isReverse)
            {
                DOVirtual.DelayedCall(.85F, () =>
                {
                    foreach (var scene in scenes.Where(scene => scene.scene != sceneName))
                    {
                        SceneManager.UnloadSceneAsync(scene.scene);
                        scene.userInterface.Animate(ProcessDuration / 2.5F, 
                            false, 0F, false);
                    }
                });
            }

            else
            {
                foreach (var scene in scenes.Where(scene => scene.scene != sceneName))
                {
                    SceneManager.LoadSceneAsync(scene.scene, LoadSceneMode.Additive);
                    scene.userInterface.Animate(ProcessDuration, true, 0F);
                }
            }
        }
    }
}