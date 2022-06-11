using System;
using System.Collections.Generic;
using AreaSystem.Class.PlaceArea;
using BlockSystem;
using DetectorSystem.Base;
using DetectorSystem.Class;
using UnityEngine;

namespace PlacerSystem.Base
{
    public abstract class PlacerBase : BlockableMonobehaviour
    {
        protected DetectorBase<IPlaceableArea> PlaceableAreaDetector { get; set; }
        
        #region Initialization
        
        public virtual void Initialize()
        {
            PlaceableAreaDetector = GetComponentInChildren<PlaceableAreaDetector>();
        }
        
        #endregion

        protected virtual bool CanPlace()
        {
            return PlaceableAreaDetector.DetectionState != null;
        }

        public virtual void PlaceElements(List<IPlaceable> target, Action<bool> onComplete = null)
        {
            if (!CanPlace())
            {
                Debug.LogWarning(($"{name} didn't detect any IPlaceable area!"));
                onComplete?.Invoke(false);
                return;
            }
            
            for (var i = target.Count - 1; i >= 0; i--)
            {
                var elem = target[i];
                PlaceableAreaDetector.DetectionState.OnReceivePlaceableElement(elem);
                elem.UnPossesBy();
                target.RemoveAt(i);
            }
            
            onComplete?.Invoke(true);
        }
    }
}