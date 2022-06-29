using UnityEngine;

namespace SourceSystem.Class
{
    public class CanProcess : IProcessable
    {
        private readonly GameObject _target = null;
        public CanProcess(GameObject gameObject)
        {
            _target = gameObject;
        }
        public GameObject GetTarget()
        {
            return _target;
        }
    }
}