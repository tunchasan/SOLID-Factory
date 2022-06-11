using System;
using System.Collections.Generic;
using System.Linq;
using AreaSystem.Class.PlaceArea;
using DetectorSystem.Base;
using DetectorSystem.Class;
using UnityEngine;

namespace PlacerSystem.Base
{
    public abstract class PlacerBase : MonoBehaviour
    {
        public DetectorBase<IPlaceableArea> PlaceableAreaDetector { get; private set; }

        private readonly List<IPlaceable> _placeableElements = new List<IPlaceable>();

        public Action<List<IPlaceable>> OnPlace;
        public void OnReceiveElement(GameObject elem)
        {
            if (elem.TryGetComponent(out IPlaceable target))
            {
                _placeableElements.Add(target);
            }
        }
        public virtual void PlaceElements(IPlaceableArea area)
        {
            OnPlace?.Invoke(_placeableElements);
            
            area.OnReceivePlaceableElements(_placeableElements);
            
            for (var i = _placeableElements.Count - 1; i >= 0; i--)
            {
                _placeableElements[i].UnPossesBy();
                _placeableElements.RemoveAt(i);
            }
        }
        
        #region Initialization
        public void Initialize()
        {
            PlaceableAreaDetector = GetComponentInChildren<PlaceableAreaDetector>();
            PlaceableAreaDetector.OnDetectSomething += PlaceElements;
        }
        private void OnDisable()
        {
            PlaceableAreaDetector.OnDetectSomething -= PlaceElements;
        }
        #endregion
    }
}