using System;
using System.Collections.Generic;
using Factorio.Core.BlockSystem;
using Factorio.Core.DetectorSystem.Base;
using Factorio.Core.DetectorSystem.Class;
using Factorio.Core.SourceSystem.Class.Storable.Base;
using Factorio.Core.StorageSystem.Utilities;
using UnityEngine;

namespace Factorio.Core.StorageSystem.Base
{
    public abstract class StorageBase : BlockableMonobehaviour
    {
        public Action<IStorable> OnStored { get; set; }
        protected abstract EntityType Type { get; set; }
        public DetectorBase<IStorable> StorableDetector { get; private set; }
        public List<IStorable> Storages { get; private set; } = new List<IStorable>();

        #region Initializations

        public override void Initialize(bool hasBlocked)
        {
            StorableDetector = GetComponentInChildren<StorableDetector>();
            
            base.Initialize(hasBlocked);
            
            StorableDetector.OnDetectionSomething += StoreElement;
        }

        private void OnDisable()
        {
            StorableDetector.OnDetectionSomething -= StoreElement;
        }

        #endregion

        public virtual void StoreElement(IStorable elem)
        {
            if (CanStoreElement(elem))
            {
                Storages.Add(elem);
                elem.PossesBy(transform);
                OnStored?.Invoke(elem);
            }
        }
        protected virtual bool CanStoreElement(IStorable elem)
        {
            if (HasBlocked)
            {
                Debug.LogWarning(($"Storage process has blocked in {name}"));

                return false;
            }
            
            return elem != null
                   && !Storages.Contains(elem)
                   && elem.Type == Type
                   && elem is CanStore;
        }
        protected virtual bool CanRemoveElement(IStorable elem)
        {
            if (HasBlocked)
            {
                Debug.LogWarning(($"Storage process has blocked in {name}"));

                return false;
            }
            
            if (elem == null)
            {
                Debug.LogWarning($"{elem} : Null element can not be removed in {name}");
                
                return false;
            }

            return true;
        }
        public void RemoveElement(IStorable targetElem)
        {
            if (CanRemoveElement(targetElem))
            {
                Debug.Log($"{Storages.Count} : Storage Elements Before Placing in {name}");

                Storages.Remove(targetElem);

                Debug.Log($"{Storages.Count} : Storage Elements After Placing in {name}");
            }
        }
        public void RemoveElements(List<IStorable> targetElements)
        {
            Debug.Log($"{Storages.Count} : Storage Elements Before Placing");

            foreach (var elem in targetElements)
            {
                RemoveElement(elem);
            }

            Debug.Log($"{Storages.Count} : Storage Elements After Placing");
        }
    }
}