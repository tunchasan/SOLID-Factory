using System.Collections.Generic;
using StorageSystem.Utilities;
using UnityEngine;

namespace StorageSystem.Base
{
    public abstract class StorageBase : MonoBehaviour
    {
        protected abstract StorageType Type { get; set; }

        public List<GameObject> Storages { get; protected set; } = new List<GameObject>();

        public bool StoreElement(IStorable elem)
        {
            if (CanStoreElement(elem))
            {
                Storages.Add(elem.GetTarget());
                elem.PossesBy(transform);
                return true;
            }

            return false;
        }

        protected virtual bool CanStoreElement(IStorable elem)
        {
            return elem != null 
                   &&
                   !Storages.Contains(elem.GetTarget())
                   &&
                   elem.Type == Type;
        }
    }
}