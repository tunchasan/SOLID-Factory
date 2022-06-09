using System.Collections.Generic;
using StorageSystem.Utilities;
using UnityEngine;

namespace StorageSystem.Base
{
    public abstract class StorageBase : MonoBehaviour
    {
        protected abstract StorageType Type { get; set; }

        public List<IStorable> Storages { get; protected set; } = new List<IStorable>();

        public bool StoreElement(IStorable elem)
        {
            if (CanStoreElement(elem))
            {
                Storages.Add(elem);
                elem.PossesBy(transform);
                return true;
            }

            return false;
        }

        private bool CanStoreElement(IStorable elem)
        {
            return !Storages.Contains(elem) 
                   &&
                   elem != null
                   &&
                   elem.Type == Type;
        }
    }
}