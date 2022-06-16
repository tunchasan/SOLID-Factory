using SourceSystem.Base.Old;
using UnityEngine;

namespace SourceSystem.Class.Old
{
    public class MultipleInteractableSourceBase : InteractableSourceBase
    {
        public override void PossesBy(Transform instigator)
        {
            transform.SetParent(instigator);           
        }
        
        public override void UnPossesBy()
        {
            transform.SetParent(null);
        }
    }
}