using System;
using System.Collections.Generic;
using AreaSystem.Base;
using GameEventsSystem;
using PlacerSystem.Base;
using UnityEngine;

namespace AreaSystem.Class.PlaceArea.Base
{
    public abstract class PlaceableAreaBase : AreaBase, IPlaceableArea
    {
        protected AreaPlacerBase AreaPlacer = null;
        public Action<IPlaceable> OnPlacedElementToArea { get; set; }

        #region Initialization

        protected virtual void Initialize()
        {
            AreaPlacer = GetComponentInChildren<AreaPlacerBase>();
            AreaPlacer.Initialize();
        }

        private void OnEnable()
        {
            GameEvents.StartEvent += Initialize;
        }

        private void OnDisable()
        {
            GameEvents.StartEvent -= Initialize;
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
                    OnPlacedElementToArea?.Invoke(element);
                }
            });
        }
    }
}