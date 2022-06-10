using System.Collections.Generic;
using DetectorSystem.Base;
using DetectorSystem.Class;
using StorageSystem.Utilities;
using UnityEngine;

namespace StorageSystem.Base
{
    public abstract class StorageBase : MonoBehaviour
    {
        protected abstract StorageType Type { get; set; }
        public DetectorBase StorableDetector { get; private set; }
        public List<GameObject> Storages { get; private set; } = new List<GameObject>();
        public virtual void StoreElement(IDetectable detectedObject)
        {
            var elem = detectedObject as IStorable;
            
            if (CanStoreElement(elem))
            {
                Storages.Add(elem.GetTarget());
                elem.PossesBy(transform);
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