using System;
using AreaSystem.Class.PlaceArea.Base;
using PlacerSystem.Base;
using SourceSystem.Class.Placeable.Base;
using UnityEngine;

namespace AreaSystem.Class.PlaceArea.Class
{
    public class MessyAreaPlacer : AreaPlacerBase
    {
        public override void Place(IPlaceable element, Action<bool> onComplete = null)
        {
            if (PlacedElements.Contains(element))
            {
                onComplete?.Invoke(false);
                
                Debug.LogWarning($"{element} already added to {name} list.");
                
                return;
            }
            
            PlacedElements.Add(element);
            
            onComplete?.Invoke(true);
        }
    }
}