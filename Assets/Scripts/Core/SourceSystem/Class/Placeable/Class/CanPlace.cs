using Factorio.Core.SourceSystem.Class.Placeable.Base;
using UnityEngine;

namespace Factorio.Core.SourceSystem.Class.Placeable.Class
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