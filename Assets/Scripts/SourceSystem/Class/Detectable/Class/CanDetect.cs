using SourceSystem.Class.Detectable.Base;
using UnityEngine;

namespace SourceSystem.Class.Detectable.Class
{
    public class CanDetect : IDetectable
    {
        private readonly GameObject _target;

        public CanDetect(GameObject target)
        {
            _target = target;
        }

        public GameObject GetTarget()
        {
            return _target;
        }
    }
}