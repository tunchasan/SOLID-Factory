using SourceSystem.Base;
using UnityEngine;

namespace SourceSystem.Class
{
    public class SingleInteractableSourceBase : InteractableSourceBase
    {
        public override void PossesBy(Transform instigator)
        {
            if (CanStore)
            {
                CanStore = false;
                
                transform.SetParent(instigator);           
            }
        }
        
        public override void UnPossesBy()
        {
            transform.SetParent(null);
        }
    }
}