using SourceSystem.Class.Transportable.Base;
using UnityEngine;

namespace SourceSystem.Class.Transportable.Class
{
    public class CanNotTransport : ITransportable
    {
        public GameObject GetTarget()
        {
            return null;
        }
    }
}