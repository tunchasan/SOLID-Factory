using Factorio.Core.SourceSystem.Class.Processable.Base;
using UnityEngine;

namespace Factorio.Core.SourceSystem.Class.Processable.Class
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