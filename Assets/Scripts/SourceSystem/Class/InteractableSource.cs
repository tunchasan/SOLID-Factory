using DropSystem.Base;
using SourceSystem.Base;
using StorageSystem.Base;
using StorageSystem.Utilities;
using UnityEngine;

namespace SourceSystem.Class
{
    public class InteractableSource : SourceBase, IStorable, IDroppable
    {
        public bool CanStorable { get; protected set; } = true;
        public StorageType Type { get; protected set; } = StorageType.Source;
        
        public virtual void PossesBy(Transform instigator)
        {
            transform.SetParent(instigator);           
        }

        public virtual void UnPossesBy()
        {
            transform.SetParent(null);
        }

        public virtual GameObject GetTarget()
        {
            return gameObject;
        }
    }
}