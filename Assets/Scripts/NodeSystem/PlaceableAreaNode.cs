using System;
using System.Collections;
using System.Collections.Generic;
using AreaSystem.Class.PlaceArea.Base;
using DetectorSystem.Class;
using PlacerSystem.Base;
using UnityEngine;

namespace NodeSystem
{
    public class PlaceableAreaNode : PlaceableAreaBase, INode<IPlaceable>
    {
        public Queue<IPlaceable> Elements { get; protected set; } = new();
        public Action<INode, List<GameObject>> OnOutput { get; set; }
        public float Duration { get; protected set; } = .25F;
        
        public void InitializeNode()
        {
            StartCoroutine(Process());
        }
        public IEnumerable<GameObject> Input(IEnumerable<GameObject> elements)
        {
            var notSuitableElements = new List<GameObject>();

            foreach (var element in elements)
            {
                var validatedElement = element.ConvertToPlaceable();
                
                if (validatedElement != null && !Elements.Contains(validatedElement))
                {
                    Elements.Enqueue(validatedElement);
                }

                else
                {
                    notSuitableElements.Add(element);
                }
            }

            Debug.Log($"Total input element's count : {Elements.Count}");

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

                    // TODO : Process and Output
                    
                    // NOTE : The process must last as long as the "duration"!
                }
                
                yield return new WaitForSeconds(Duration);

                if (processingElement != null)
                {
                    Output(processingElement);
                    
                    Debug.Log($"{processingElement} element is processed by {name}");
                }
            }
        }
        public void Output(IPlaceable output)
        {
            OnOutput?.Invoke(this, new List<GameObject>{output.GetTarget()});
            
            Debug.Log($"Updated input element's count : {Elements.Count}");
        }
        protected override void OnElementPlaced(IPlaceable element)
        {
            base.OnElementPlaced(element);
            
            Input(new List<GameObject>{element.GetTarget()});
        }
    }
}