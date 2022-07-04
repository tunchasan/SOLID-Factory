using Factorio.Core.SourceSystem.Class.Transportable.Base;
using UnityEngine;

namespace Factorio.Core.SourceSystem.Class.Transportable.Class
{
    public class CanNotTransport : ITransportable
    {
        public GameObject GetTarget()
        {
            return null;
        }
    }
}