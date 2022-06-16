using PlacerSystem.Base;
using UnityEngine;

namespace SourceSystem.Class
{
    public class CanNotPlace : IPlaceable
    {
        public GameObject GetTarget()
        {
            return null;
        }

        public void UnPossesBy()
        {
            // no-op
        }
    }
}