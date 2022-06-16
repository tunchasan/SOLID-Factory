using ConveyorBeltSystem.Base;
using UnityEngine;

namespace SourceSystem.Class
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