using System;
using System.Collections;
using System.Collections.Generic;
using DetectorSystem.Class;
using DG.Tweening;
using NodeSystem.Nodes.Base;
using SourceSystem.Class.Transportable.Base;
using UnityEngine;

namespace NodeSystem.ConveyorBelt.Class
{
    public class ConveyorBeltNode : MonoBehaviour, INode<ITransportable>
    {
        [SerializeField] protected Transform startLocation = null;
        [SerializeField] protected Transform endLocation = null;

        public Queue<ITransportable> Elements { get; protected set; } = new();
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
                if (element.TryGetTransportable(out var transportable))
                {
                    if (!Elements.Contains(transportable))
                    {
                        Elements.Enqueue(transportable);
                    }
                }

                else
                {
                    notSuitableElements.Add(element);
                }
            }

            Debug.Log($"ConveyorBeltNode :: Total inputs count : {Elements.Count}");

            return notSuitableElements;
        }
        public IEnumerator Process()
        {
            var startPosition = startLocation.position;
            var finalPosition = endLocation.position;
            var conveyorLength = Vector3.Distance(startPosition, finalPosition);

            var conveyorPath = new Vector3[2];
            conveyorPath[0] = startPosition;
            conveyorPath[1] = finalPosition;
            
            while (true)
            {
                ITransportable processingElement = null;
                
                if (Elements.Count > 0)
                {
                    processingElement = Elements.Dequeue();

                    var estimatedTime = conveyorLength * Duration;
                    var target = processingElement.GetTarget().transform;
                    
                    target.DOPath(conveyorPath, estimatedTime).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        Debug.Log($"ConveyorBeltNode :: {processingElement} element is processed");
                            
                        Output(processingElement.GetTarget());
                    });
                }
                
                yield return _waitForSeconds;
            }
        }
        public void Output(GameObject output)
        {
            Debug.Log($"ConveyorBeltNode :: Remained element's count is {Elements.Count}");

            OnOutput?.Invoke(this, new List<GameObject>{output});
        }
    }
}
