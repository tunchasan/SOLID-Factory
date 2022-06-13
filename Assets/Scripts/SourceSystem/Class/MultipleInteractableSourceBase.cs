using SourceSystem.Base;
using UnityEngine;

namespace SourceSystem.Class
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