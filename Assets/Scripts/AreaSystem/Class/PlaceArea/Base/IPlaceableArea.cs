using System;
using System.Collections.Generic;
using DetectorSystem.Base;
using PlacerSystem.Base;

namespace AreaSystem.Class.PlaceArea.Base
{
    public interface IPlaceableArea : IDetectable
    {
        void OnReceivePlaceableElements(List<IPlaceable> elements, Action<bool> onComplete);
        void OnReceivePlaceableElement(IPlaceable element);
    }
}