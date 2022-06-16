using SourceSystem.Base.Old;
using UnityEngine;

namespace SourceSystem.Class.Old
{
    public class SingleInteractableSourceBase : InteractableSourceBase
    {
        public override void PossesBy(Transform instigator)
        {
            if (Status)
            {
                Status = false;
                
                transform.SetParent(instigator);           
            }
        }
        
        public override void UnPossesBy()
        {
            transform.SetParent(null);
        }
    }
}