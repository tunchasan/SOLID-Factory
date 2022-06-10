using System;
using System.Collections.Generic;
using UnityEngine;

namespace DropSystem.Base
{
    public abstract class DropperBase : MonoBehaviour
    {
        public Action OnDetectDropArea;
        
        public void DropElements(List<GameObject> elements)
        {
            for (var i = elements.Count - 1; i >= 0; i--)
            {
                var droppableElem = elements[i].GetComponent<IDroppable>();
                
                if (CanDropElement(droppableElem))
                {
                    droppableElem.UnPossesBy();

                    elements.RemoveAt(i);
                }
            }
        }

        protected virtual bool CanDropElement(IDroppable elem)
        {
            return elem != null;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("DropArea-Dummy"))
            {
                OnDetectDropArea?.Invoke();
            }
        }
    }
}