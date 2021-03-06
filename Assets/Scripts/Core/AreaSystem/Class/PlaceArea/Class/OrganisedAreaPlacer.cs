using System;
using Factorio.Core.AreaSystem.Class.PlaceArea.Base;
using Factorio.Core.SourceSystem.Class.Placeable.Base;
using UnityEngine;

namespace Factorio.Core.AreaSystem.Class.PlaceArea.Class
{
    public class OrganisedAreaPlacer : AreaPlacerBase
    {
        public override void Place(IPlaceable element, Action<bool> onComplete = null)
        {
            if (element.GetTarget() == null)
            {
                onComplete?.Invoke(false);
                
                Debug.Log($"{element} is not suitable.");
                
                return;
            }
            
            if (PlacedElements.Contains(element))
            {
                onComplete?.Invoke(false);
                
                Debug.Log($"{element} already added to {name} list.");
                
                return;
            }
            
            AreaPlacerAnimation.AnimatePlacing(element.GetTarget().transform, status =>
            {
                if (status)
                    PlacedElements.Add(element);
                
                onComplete?.Invoke(status);
            });
        }
    }
}