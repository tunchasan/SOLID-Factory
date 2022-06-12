using System.Linq;
using BlockSystem;
using PlacerSystem.Base;
using StorageSystem.Base;
using UnityEngine;

namespace TankSystem.Units.PlacerUnit.Base
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

            var placeElements = _storage.Storages
                .Select(storeElem => storeElem.GetTarget().GetComponent<IPlaceable>())
                .Where(placeElem => placeElem != null).ToList();
            
            _placer.PlaceElements(placeElements);
        }
        protected virtual void OnPlaced(IPlaceable placedElement)
        {
            if (HasBlocked)
            {
                Debug.LogWarning(($"OnPlace process has blocked in {name}"));

                return;
            }

            _storage.RemoveElement(placedElement.GetTarget().GetComponent<IStorable>());
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