using SourceSystem.Class.Transportable.Base;
using UnityEngine;

namespace SourceSystem.Class.Transportable.Class
{
    public class CanTransport : ITransportable
    {
        private readonly GameObject _target = null;
        public CanTransport(GameObject target)
        {
            _target = target;
        }
        public GameObject GetTarget()
        {
            return _target;
        }
    }
}