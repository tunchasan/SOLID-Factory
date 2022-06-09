using System;
using System.Collections.Generic;
using UnityEngine;

namespace DropSystem.Base
{
    public class DropperBase : MonoBehaviour
    {
        public Action OnDetectDropArea;
        
        public void DropElements(List<IDroppable> elements)
        {
            foreach (var elem in elements)
            {
                elem.UnPossesBy();
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            // TODO
            
            // Check if it's DropArea
            
            // Invoke OnDetectDropArea
        }
    }
}