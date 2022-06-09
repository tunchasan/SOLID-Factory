using SourceSystem.Base;
using StorageSystem.Base;
using StorageSystem.Utilities;
using UnityEngine;

namespace SourceSystem.Class
{
    public class StorableSource : SourceBase, IStorable
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