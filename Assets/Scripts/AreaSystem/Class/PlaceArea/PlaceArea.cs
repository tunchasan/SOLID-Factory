using AreaSystem.Base;
using UnityEngine;

namespace AreaSystem.Class.PlaceArea
{
    public class PlaceArea : AreaBase, IPlaceableArea
    {
        public GameObject GetTarget()
        {
            return gameObject;
        }
    }
}