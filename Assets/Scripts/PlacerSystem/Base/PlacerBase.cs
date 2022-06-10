using System.Collections.Generic;
using DetectorSystem.Base;
using DetectorSystem.Class;
using UnityEngine;

namespace PlacerSystem.Base
{
    public abstract class PlacerBase : MonoBehaviour
    {
        public DetectorBase PlaceableAreaDetector { get; private set; }
        public void Initialize()
        {
            PlaceableAreaDetector = GetComponentInChildren<PlaceableAreaDetector>();
        }
        public virtual void PlaceElements(List<GameObject> elements)
        {
            for (var i = elements.Count - 1; i >= 0; i--)
            {
                var placeableElem = elements[i].GetComponent<IPlaceable>();
                
                if (CanPlaceElement(placeableElem))
                {
                    placeableElem.UnPossesBy();

                    elements.RemoveAt(i);
                }
            }
        }
        protected virtual bool CanPlaceElement(IPlaceable elem)
        {
            return elem != null;
        }
    }
}