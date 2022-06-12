using SourceSystem.Base;
using UnityEngine;

namespace SourceSystem.Class
{
    public class SingleInteractableSourceBase : InteractableSourceBase
    {
        public override void PossesBy(Transform instigator)
        {
            if (CanStorable)
            {
                CanStorable = false;
                
                transform.SetParent(instigator);           
            }
        }
    }
}