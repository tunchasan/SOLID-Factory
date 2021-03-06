using System;
using System.Collections.Generic;
using Factorio.Core.AreaSystem.Class.PlaceArea.Base;
using Factorio.Core.BlockSystem;
using Factorio.Core.DetectorSystem.Base;
using Factorio.Core.DetectorSystem.Class;
using Factorio.Core.SourceSystem.Class.Placeable.Base;

namespace Factorio.Core.PlacerSystem.Base
{
    public abstract class PlacerBase : BlockableMonobehaviour
    {
        public Action<IPlaceable> OnPlaced { get; set; }
        public Action OnPlaceRequest { get; set; }
        protected DetectorBase<IPlaceableArea> placeableAreaDetector { get; set; }
        
        #region Initialization
        
        public override void Initialize(bool hasBlocked)
        {
            placeableAreaDetector = GetComponentInChildren<PlaceableAreaDetector>();
            placeableAreaDetector.OnDetectionSomething += CreatePlaceRequest;
            base.Initialize(hasBlocked);
        }
        private void OnDisable()
        {
            placeableAreaDetector.OnDetectionSomething -= CreatePlaceRequest;
        }
        
        #endregion

        protected abstract bool CanPlace();
        private void CreatePlaceRequest(IPlaceableArea placeableArea)
        {
            OnPlaceRequest?.Invoke();
        }
        public virtual void PlaceElements(List<IPlaceable> target, Action<bool> onComplete = null)
        {
            if (!CanPlace())
            {
                onComplete?.Invoke(false);
                return;
            }
            
            for (var i = target.Count - 1; i >= 0; i--)
            {
                var elem = target[i];
                elem.UnPossesBy();
                placeableAreaDetector.DetectionState.OnReceivePlaceableElement(elem);
                target.RemoveAt(i);
                OnPlaced?.Invoke(elem);
            }
            
            onComplete?.Invoke(true);
        }
    }
}