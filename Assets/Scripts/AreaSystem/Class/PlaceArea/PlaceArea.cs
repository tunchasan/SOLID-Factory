using System.Collections.Generic;
using AreaSystem.Base;
using PlacerSystem.Base;
using UnityEngine;

namespace AreaSystem.Class.PlaceArea
{
    public class PlaceArea : AreaBase, IPlaceableArea
    {
        public GameObject GetTarget()
        {
            return gameObject;
        }

        public void OnReceivePlaceableElements(List<IPlaceable> elements)
        {
            // TODO
        }
    }
}