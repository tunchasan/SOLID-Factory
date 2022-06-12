using System;
using System.Collections.Generic;
using AreaSystem.Base;
using PlacerSystem.Base;
using UnityEngine;

namespace AreaSystem.Class.PlaceArea.Base
{
    public abstract class PlaceableAreaBase : AreaBase, IPlaceableArea
    {
        protected AreaPlacerBase AreaPlacer = null;
        public Action OnPlacedElementToArea { get; set; }

        #region Initialization
        
        private void Start()
        {
            Initialize();
        }
        protected virtual void Initialize()
        {
            AreaPlacer = GetComponentInChildren<AreaPlacerBase>();
            AreaPlacer.Initialize();
        }
        
        #endregion
        
        public GameObject GetTarget()
        {
            return gameObject;
        }
        
        public void OnReceivePlaceableElements(List<IPlaceable> elements)
        {
            Debug.Log($"{elements.Count} new object received to placeArea");
            
            foreach (var elem in elements)
            {
                OnReceivePlaceableElement(elem);
            }
            
            Debug.Log($"{AreaPlacer.PlacedElements.Count} objects placed to placeArea");
        }
        public void OnReceivePlaceableElement(IPlaceable element)
        {
            AreaPlacer.Place(element, (status) =>
            {
                if (status)
                {
                    OnPlacedElementToArea?.Invoke();
                }
            });
        }
    }
}