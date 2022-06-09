using System.Collections.Generic;
using StorageSystem.Utilities;
using UnityEngine;

namespace StorageSystem.Base
{
    public abstract class StorageBase : MonoBehaviour
    {
        protected abstract StorageType Type { get; set; }
    
        private readonly List<IStorable> _storages = new List<IStorable>();

        public bool StoreElement(IStorable elem)
        {
            if (CanStoreElement(elem))
            {
                _storages.Add(elem);
                elem.PossesBy(transform);
                return true;
            }

            return false;
        }

        private bool CanStoreElement(IStorable elem)
        {
            return !_storages.Contains(elem) 
                   &&
                   elem != null
                   &&
                   elem.Type == Type;
        }
    }
}