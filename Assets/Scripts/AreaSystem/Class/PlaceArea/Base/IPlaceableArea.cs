using System;
using System.Collections.Generic;
using DetectorSystem.Base;
using PlacerSystem.Base;
using SourceSystem.Class.Detectable.Base;
using SourceSystem.Class.Placeable.Base;

namespace AreaSystem.Class.PlaceArea.Base
{
    public interface IPlaceableArea : IDetectable
    {
        void OnReceivePlaceableElements(List<IPlaceable> elements, Action<bool> onComplete);
        void OnReceivePlaceableElement(IPlaceable element);
    }
}