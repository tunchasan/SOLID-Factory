using System.Collections.Generic;
using Factorio.Core.BlockSystem;
using Factorio.Core.PlacerSystem.Base;
using Factorio.Core.SourceSystem.Class;
using Factorio.Core.SourceSystem.Class.Placeable.Base;
using Factorio.Core.SourceSystem.Class.Storable.Base;
using Factorio.Core.StorageSystem.Base;
using UnityEngine;

namespace Factorio.Core.TankSystem.Units.PlacerUnit.Base
{
    public abstract class PlacerUnitBase : BlockableMonobehaviour
    {
        private StorageBase _storage = null;
        private PlacerBase _placer = null;

        #region Initializations
        public override void Initialize(bool hasBlocked)
        {
            _storage = GetComponentInChildren<StorageBase>();
            _placer = GetComponentInChildren<PlacerBase>();
            
            base.Initialize(hasBlocked);
            _placer.Initialize(hasBlocked);
            _storage.Initialize(hasBlocked);
            
            _placer.OnPlaceRequest += Place;
            _placer.OnPlaced += OnPlaced;
            _storage.OnStored += OnStored;
        }
        private void OnDisable()
        {
            _placer.OnPlaceRequest -= Place;
            _placer.OnPlaced -= OnPlaced;
            _storage.OnStored -= OnStored;
        }
        #endregion
        
        public virtual void Store(IStorable storableElem)
        {
            if (HasBlocked)
            {
                Debug.LogWarning(($"Store process has blocked in {name}"));

                return;
            }
            
            _storage.StoreElement(storableElem);
        }
        public virtual void Place()
        {
            if (HasBlocked)
            {
                Debug.LogWarning(($"Place process has blocked in {name}"));

                return;
            }

            var placeElements = new List<IPlaceable>();

            foreach (var target in _storage.Storages)
            {
                if (target.GetTarget().TryGetPlaceable(out var placeable))
                {
                    placeElements.Add(placeable);
                }
            }
            
            _placer.PlaceElements(placeElements);
        }
        protected virtual void OnPlaced(IPlaceable placedElement)
        {
            if (HasBlocked)
            {
                Debug.LogWarning(($"OnPlace process has blocked in {name}"));

                return;
            }

            var target = placedElement.GetTarget();
            if (target.TryGetStorable(out var storable))
                _storage.RemoveElement(storable);
        }
        protected virtual void OnStored(IStorable storedElement)
        {
            if (HasBlocked)
            {
                Debug.LogWarning(($"OnPlace process has blocked in {name}"));

                return;
            }
            
            // TODO
        }

        public override void Block()
        {
            base.Block();
            _placer.Block();
        }
        public override void UnBlock()
        {
            base.UnBlock();
            _placer.UnBlock();
            _storage.UnBlock();
        }
    }
}