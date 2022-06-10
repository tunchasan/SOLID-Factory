using UnityEngine;

namespace SourceSystem.Class
{
    public class SingleInteractableSource : InteractableSource
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