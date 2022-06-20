using PlacerSystem.Base;
using UnityEngine;

namespace SourceSystem.Class
{
    public class CanPlace : IPlaceable
    {
        private readonly GameObject _target = null;

        public CanPlace(GameObject target)
        {
            _target = target;
        }
        
        public GameObject GetTarget()
        {
            return _target;
        }
        public void UnPossesBy()
        {
            _target.transform.SetParent(null);
        }
    }
}