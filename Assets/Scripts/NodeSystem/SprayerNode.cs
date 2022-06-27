using System;
using System.Collections;
using System.Collections.Generic;
using DetectorSystem.Class;
using DG.Tweening;
using PlacerSystem.Base;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NodeSystem
{
    public class SprayerNode : MonoBehaviour, INode<IPlaceable>
    {
        [SerializeField] private Transform sprayCenter = null;
        [SerializeField] private Transform sprayTarget = null;
        
        public Queue<IPlaceable> Elements { get; protected set; } = new();
        public Action<INode, List<GameObject>> OnOutput { get; set; }
        public float Duration { get; protected set; } = .5F;
        
        public void InitializeNode()
        {
            StartCoroutine(Process());
        }
        public IEnumerable<GameObject> Input(IEnumerable<GameObject> elements)
        {
            var notSuitableElements = new List<GameObject>();

            foreach (var element in elements)
            {
                if (element.TryGetPlaceable(out var placeable))
                {
                    if (!Elements.Contains(placeable))
                    {
                        Elements.Enqueue(placeable);
                    }
                }

                else
                {
                    notSuitableElements.Add(element);
                }
            }

            Debug.Log($"PlaceableAreaNode :: Total inputs count : {Elements.Count}");

            return notSuitableElements;
        }
        public IEnumerator Process()
        {
            while (true)
            {
                IPlaceable processingElement = null;
                
                if (Elements.Count > 0)
                {
                    processingElement = Elements.Dequeue();

                    var targetTransform = processingElement.GetTarget().transform;

                    var randomPoint = Random.insideUnitCircle * 1.5F;
                    
                    var sprayPosition = sprayCenter.position + new Vector3(randomPoint.x, randomPoint.y, 0F);

                    // REFACTOR - ANIMATION
                    
                    Vector3 dir = sprayPosition - transform.position;
                    float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
                    var targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

                    sprayTarget.DORotateQuaternion(targetRotation, Duration / 2F).OnComplete(() =>
                    {
                        sprayTarget.DOScaleX(.6F, Duration / 2F).OnComplete(() =>
                        {
                            sprayTarget.DOScaleX(.5F, Duration / 2F);
                        });
                        
                        targetTransform.DOMove(sprayPosition, .5F).SetEase(Ease.OutExpo);

                        sprayTarget.DOLocalRotate(Vector3.zero, Duration / 2F);
                    });
                    
                    // REFACTOR - ANIMATION
                }
                
                yield return new WaitForSeconds(Duration);

                if (processingElement != null)
                {
                    Debug.Log($"PlaceableAreaNode :: {processingElement} element is processed");
                    
                    Output(processingElement);
                }
            }
        }

        public void Output(IPlaceable output)
        {
            Debug.Log($"PlaceableAreaNode :: Remained element's count is {Elements.Count}");

            OnOutput?.Invoke(this, new List<GameObject>{output.GetTarget()});
        }
    }
}