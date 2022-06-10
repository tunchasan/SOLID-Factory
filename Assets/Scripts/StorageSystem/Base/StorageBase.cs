using System;
using System.Collections.Generic;
using DetectorSystem.Base;
using DetectorSystem.Class;
using StorageSystem.Utilities;
using UnityEngine;

namespace StorageSystem.Base
{
    public abstract class StorageBase : MonoBehaviour
    {
        public Action<IStorable> OnStore;
        protected abstract StorageType Type { get; set; }
        public DetectorBase<IStorable> StorableDetector { get; private set; }
        public List<GameObject> Storages { get; private set; } = new List<GameObject>();
        public virtual void StoreElement(IStorable elem)
        {
            if (CanStoreElement(elem))
            {
                Storages.Add(elem.GetTarget());
                elem.PossesBy(transform);
                OnStore?.Invoke(elem);
            }
        }
        protected virtual bool CanStoreElement(IStorable elem)
        {
            return elem != null 
                   &&
                   !Storages.Contains(elem.GetTarget())
                   &&
                   elem.Type == Type;
        }
        
        #region Initializations

        public virtual void Initialize()
        {
            StorableDetector = GetComponentInChildren<StorableDetector>();
            StorableDetector.OnDetectSomething += StoreElement;
        }
        
        private void OnDisable()
        {
            StorableDetector.OnDetectSomething -= StoreElement;
        }

        #endregion
    }
}