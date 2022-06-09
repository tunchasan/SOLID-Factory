using DropSystem.Base;
using SourceSystem.Base;
using StorageSystem.Base;
using StorageSystem.Utilities;
using UnityEngine;

namespace SourceSystem.Class
{
    public class InteractableSource : SourceBase, IStorable, IDroppable
    {
        public StorageType Type { get; protected set; } = StorageType.Source;
        
        public void PossesBy(Transform instigator)
        {
            transform.SetParent(instigator);
        }

        public void UnPossesBy()
        {
            transform.SetParent(null);
        }
    }
}