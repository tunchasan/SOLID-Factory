using System;
using AreaSystem.Class.PlaceArea.Base;
using PlacerSystem.Base;
using UnityEngine;

namespace AreaSystem.Class.PlaceArea.Class
{
    public class OrganisedAreaPlacer : AreaPlacerBase
    {
        public override void Place(IPlaceable element, Action<bool> onComplete = null)
        {
            if (PlacedElements.Contains(element))
            {
                onComplete?.Invoke(false);
                
                Debug.Log($"{element} already added to {name} list.");
                
                return;
            }
            
            AreaPlacerAnimation.AnimatePlacing(element.GetTarget().transform, status =>
            {
                if (status)
                {
                    PlacedElements.Add(element);
                }
            });
            
            onComplete?.Invoke(true);
        }
    }
}