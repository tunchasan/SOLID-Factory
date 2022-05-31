using System.Collections.Generic;
using UnityEngine;

namespace StorageSystem
{
    public abstract class Storage : MonoBehaviour
    {
        [SerializeField] protected int capacity = 1;

        public abstract StorageType Type { get; }
    
        private List<IStorable> _storages = new List<IStorable>();

        public bool StoreElement(IStorable elem)
        {
            if (_storages.Count < capacity)
            {
                _storages.Add(elem);

                return true;
            }

            return false;
        }

        public IStorable DropFirstElement()
        {
            if (_storages.Count > 0)
            {
                var elem = _storages[0];
                _storages.RemoveAt(0);
                return elem;
            }
        
            return null;
        }
    }
}