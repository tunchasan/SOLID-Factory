using System;
using System.Collections.Generic;
using Factorio.Core.SourceSystem.Class.Detectable.Base;
using Factorio.Core.SourceSystem.Class.Placeable.Base;

namespace Factorio.Core.AreaSystem.Class.PlaceArea.Base
{
    public interface IPlaceableArea : IDetectable
    {
        void OnReceivePlaceableElements(List<IPlaceable> elements, Action<bool> onComplete);
        void OnReceivePlaceableElement(IPlaceable element);
    }
}