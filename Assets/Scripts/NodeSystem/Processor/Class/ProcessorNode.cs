using System;
using System.Collections;
using System.Collections.Generic;
using DetectorSystem.Class;
using NodeSystem.Nodes.Base;
using NodeSystem.Processor.Base;
using SourceSystem.Class.Processable.Base;
using Unity.Mathematics;
using UnityEngine;

namespace NodeSystem.Processor.Class
{
    public class ProcessorNode : MonoBehaviour, INode<IProcessable>
    {
        [SerializeField] private GameObject product = null;
        
        public Queue<IProcessable> Elements { get; protected set; } = new();
        public Action<INode, List<GameObject>> OnOutput { get; set; }
        public float Duration { get; protected set; } = .5F;
        
        private ProcessorAnimationBase _processorAnimation;
        private YieldInstruction _waitForSeconds;
        
        public void InitializeNode()
        {
            StartCoroutine(Process());
            _waitForSeconds = new WaitForSeconds(Duration);

            _processorAnimation = GetComponent<ProcessorAnimationBase>();
            if (_processorAnimation == null)
                _processorAnimation = gameObject.AddComponent<ProcessorAnimation>();

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

                    Destroy(processingElement.GetTarget());

                    output = Instantiate(product, transform.position, 
                        quaternion.identity).gameObject;
                    
                    _processorAnimation.Animate(Duration);
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
