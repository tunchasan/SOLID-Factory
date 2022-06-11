using System.Collections.Generic;
using AreaSystem.Base;
using PlacerSystem.Base;
using UnityEngine;

namespace AreaSystem.Class.PlaceArea
{
    public class PlaceArea : AreaBase, IPlaceableArea
    {
        private readonly List<IPlaceable> _placedElements = new();
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
            
            Debug.Log($"{_placedElements.Count} objects placed to placeArea");
        }
        public void OnReceivePlaceableElement(IPlaceable element)
        {
            if(!_placedElements.Contains(element))
                _placedElements.Add(element);
        }
        protected override void OnTriggerEnter2D(Collider2D col)
        {
            if(col.TryGetComponent(out IPlaceable placeable))
                OnReceivePlaceableElement(placeable);
        }
    }
}

