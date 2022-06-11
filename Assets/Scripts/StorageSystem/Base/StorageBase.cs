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
        public List<IStorable> Storages { get; private set; } = new List<IStorable>();

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

        public virtual void StoreElement(IStorable elem)
        {
            if (CanStoreElement(elem))
            {
                Storages.Add(elem);
                elem.PossesBy(transform);
                OnStore?.Invoke(elem);
            }
        }
        protected virtual bool CanStoreElement(IStorable elem)
        {
            return elem != null
                   &&
                   !Storages.Contains(elem)
                   &&
                   elem.Type == Type;
        }
        public void RemoveElements(List<GameObject> targetElements)
        {
            Debug.Log($"{Storages.Count} : Storage Elements Before Placing");

            foreach (var elem in targetElements)
            {
                var storable = elem.GetComponent<IStorable>();
                Storages.Remove(storable);
            }

            Debug.Log($"{Storages.Count} : Storage Elements After Placing");
        }
    }
}