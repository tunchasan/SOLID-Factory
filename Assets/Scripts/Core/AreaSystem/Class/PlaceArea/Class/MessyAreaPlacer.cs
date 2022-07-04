using System;
using Factorio.Core.AreaSystem.Class.PlaceArea.Base;
using Factorio.Core.SourceSystem.Class.Placeable.Base;
using UnityEngine;

namespace Factorio.Core.AreaSystem.Class.PlaceArea.Class
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