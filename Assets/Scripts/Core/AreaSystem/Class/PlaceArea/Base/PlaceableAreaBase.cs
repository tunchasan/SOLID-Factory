using System;
using System.Collections.Generic;
using Factorio.Core.AreaSystem.Base;
using Factorio.Core.SourceSystem.Class.Placeable.Base;
using UnityEngine;
using Zenject;

namespace Factorio.Core.AreaSystem.Class.PlaceArea.Base
{
    public abstract class PlaceableAreaBase : AreaBase, IPlaceableArea
    {
        protected AreaPlacerBase AreaPlacer = null;
        public Action<IPlaceable> OnElementPlacedToArea { get; set; }

        #region Initialization

        [Inject]
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
        public void OnReceivePlaceableElements(List<IPlaceable> elements, Action<bool> onComplete)
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
                    OnElementPlaced(element);
                }
            });
        }
        protected virtual void OnElementPlaced(IPlaceable element)
        {
            OnElementPlacedToArea?.Invoke(element);
        }
    }
}