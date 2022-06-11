using System.Collections.Generic;
using DetectorSystem.Base;
using PlacerSystem.Base;

namespace AreaSystem.Class.PlaceArea
{
    public interface IPlaceableArea : IDetectable
    {
        void OnReceivePlaceableElements(List<IPlaceable> elements);
        void OnReceivePlaceableElement(IPlaceable element);
    }
}