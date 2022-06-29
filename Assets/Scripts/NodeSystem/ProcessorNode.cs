using System;
using System.Collections;
using System.Collections.Generic;
using DetectorSystem.Class;
using DG.Tweening;
using SourceSystem.Class;
using Unity.Mathematics;
using UnityEngine;

namespace NodeSystem
{
    public class ProcessorNode : MonoBehaviour, INode<IProcessable>
    {
        [SerializeField] private GameObject outputPrefab = null;
        
        public Queue<IProcessable> Elements { get; protected set; } = new();
        public Action<INode, List<GameObject>> OnOutput { get; set; }
        public float Duration { get; protected set; } = .5F;
        
        private YieldInstruction _waitForSeconds;
        
        public void InitializeNode()
        {
            StartCoroutine(Process());
            _waitForSeconds = new WaitForSeconds(Duration);
        }
        
        public IEnumerable<GameObject> Input(IEnumerable<GameObject> elements)
        {
            var notSuitableElements = new List<GameObject>();

            foreach (var element in elements)
            {
                if (element.TryGetProcessable(out var processable))
                {
                    if (!Elements.Contains(processable))
                    {
                        Elements.Enqueue(processable);
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
                GameObject output = null;
                
                if (Elements.Count > 0)
                {
                    var processingElement = Elements.Dequeue();

                    output = Instantiate(outputPrefab, transform.position, 
                        quaternion.identity).gameObject;
                    
                    Destroy(processingElement.GetTarget());

                    transform.DOScale(Vector3.one * 1.2F, Duration / 2F).OnComplete(() =>
                    {
                        transform.DOScale(Vector3.one, Duration / 2F).SetEase(Ease.OutExpo);

                    }).SetEase(Ease.OutExpo);
                }
                
                yield return _waitForSeconds;

                if (output != null)
                {
                    Debug.Log($"PlaceableAreaNode :: {output} element is processed");
                    
                    Output(output);
                }
            }
        }

        public void Output(GameObject output)
        {
            Debug.Log($"PlaceableAreaNode :: Remained element's count is {Elements.Count}");

            OnOutput?.Invoke(this, new List<GameObject>{output});        
        }
    }
}
