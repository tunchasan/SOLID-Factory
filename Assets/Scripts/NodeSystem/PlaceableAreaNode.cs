using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AreaSystem.Class.PlaceArea.Base;
using PlacerSystem.Base;
using UnityEngine;

namespace NodeSystem
{
    public class PlaceableAreaNode : PlaceableAreaBase, INode<IPlaceable>
    {
        public Queue<IPlaceable> Elements { get; protected set; } = new();
        public Action<IPlaceable> OnOutput { get; set; }
        public float Duration { get; protected set; } = .25F;

        public void InitializeNode()
        {
            StartCoroutine(Process());
        }
        public void Input(IEnumerable<IPlaceable> inputs)
        {
            var uniqueInputs = inputs.Where(element => !Elements.Contains(element));
            
            foreach (var element in uniqueInputs)
            {
                Elements.Enqueue(element);
            }

            Debug.Log(Elements.Count);
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
                }
            }
        }
        public void Output(IPlaceable output)
        {
            OnOutput(output);
        }
        protected override void OnElementPlaced(IPlaceable element)
        {
            base.OnElementPlaced(element);
            
            Input(new List<IPlaceable>{element});
        }
    }
}