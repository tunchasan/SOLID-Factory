using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
            _waitSeconds = new WaitForSeconds(ProcessDuration / 2F);
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
            
            yield return _waitSeconds;

            var image = target.userInterface.GetComponent<Image>();
            var text = target.userInterface.GetComponentInChildren<TextMeshProUGUI>();

            var alpha = 0F;
            
            var imageCurrentColor = image.color;
            var imageTargetColor = imageCurrentColor;
            imageTargetColor.a = isReverse ? .75F : 0F;
            
            var textCurrentColor = text.color;
            var textTargetColor = textCurrentColor;
            textTargetColor.a = isReverse ? 1F : 0F;

            DOTween.To(() => alpha, x => alpha = x, 1F, ProcessDuration / 2F).OnUpdate(() =>
            {
                image.color = Color.Lerp(imageCurrentColor, imageTargetColor, alpha);
                text.color = Color.Lerp(textCurrentColor, textTargetColor, alpha);
            });
            
            yield return _waitSeconds;
            _isProcessing = false;
        }

        private void HandleScenes(string sceneName, bool isReverse)
        {
            if (!isReverse)
            {
                DOVirtual.DelayedCall(ProcessDuration * .75F, () =>
                {
                    foreach (var scene in scenes.Where(scene => scene.scene != sceneName))
                    {
                        SceneManager.UnloadSceneAsync(scene.scene);
                    }
                });
            }

            else
            {
                foreach (var scene in scenes.Where(scene => scene.scene != sceneName))
                {
                    SceneManager.LoadSceneAsync(scene.scene, LoadSceneMode.Additive);
                }
            }
        }
    }

    [System.Serializable]
    public class SimulationSceneData
    {
        public string scene = "";
        public GameObject camera;
        public GameObject userInterface;
    }
}