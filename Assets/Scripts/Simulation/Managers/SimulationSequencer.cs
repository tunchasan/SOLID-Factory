using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Factorio.Simulation.Managers
{
    public class SimulationSequencer : MonoBehaviour
    {
        [SerializeField] private float simulationInterval = 1F;
        [SerializeField] private float simulationScale = 1F;
        [SerializeField] private bool isRandom = false;
        [SerializeField] private List<GameObject> simulationTargets = new();

        private void Start()
        {
            StartCoroutine(Simulate());
        }

        private IEnumerator Simulate()
        {
            var waitSecond = new WaitForSeconds(simulationInterval);
            var simulationIndex = 0;

            while (true)
            {
                if (!isRandom)
                {
                    var target = simulationTargets[simulationIndex];
                    AnimateTarget(target, !target.activeInHierarchy);
                    simulationIndex++;
                    simulationIndex %= simulationTargets.Count;
                }

                else
                {
                    var target = simulationTargets[Random.Range(0, simulationTargets.Count)];
                    AnimateTarget(target, !target.activeInHierarchy);
                }
                
                yield return waitSecond;
            }
        }

        private void AnimateTarget(GameObject target, bool enable)
        {
            if (enable)
            {
                target.SetActive(true);
                target.transform.DOScale(Vector3.one * simulationScale, simulationInterval)
                    .SetEase(Ease.OutExpo);
            }

            else
            {
                target.transform.DOScale(Vector3.zero, simulationInterval)
                    .SetEase(Ease.OutExpo)
                    .OnComplete(() => { target.SetActive(false); });
            }
        }
    }
}