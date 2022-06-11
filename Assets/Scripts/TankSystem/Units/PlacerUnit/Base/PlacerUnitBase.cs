using System.Collections.Generic;
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
            base.Initialize(hasBlocked);
            _storage = GetComponentInChildren<StorageBase>();
            _placer = GetComponentInChildren<PlacerBase>();
            _placer.Initialize();
            _storage.Initialize();
            _storage.OnStore += OnStore;
            _placer.OnPlace += OnPlace;
        }
        protected virtual void OnDisable()
        {
            _storage.OnStore -= OnStore;
            _placer.OnPlace -= OnPlace;
        }
        #endregion
        
        protected virtual void OnStore(IStorable storableElem)
        {
            if (HasBlocked)
            {
                Debug.LogWarning(($"OnStore process has blocked in {name}"));

                return;
            }
            
            _placer.OnReceiveElement(storableElem.GetTarget());
        }

        protected virtual void OnPlace(List<IPlaceable> placeElements)
        {
            if (HasBlocked)
            {
                Debug.LogWarning(($"OnPlace process has blocked in {name}"));

                return;
            }
            
            var list = placeElements.Select(elem => elem.GetTarget()).ToList();
            _storage.RemoveElements(list);
        }

        public override void Block()
        {
            base.Block();
            _storage.Block();
            _placer.Block();
        }

        public override void UnBlock()
        {
            base.UnBlock();
            _storage.UnBlock();
            _placer.UnBlock();
        }
    }
}