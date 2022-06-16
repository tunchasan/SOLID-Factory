using ConveyorBeltSystem.Base;
using UnityEngine;

namespace SourceSystem.Class
{
    public class CanNotTransport : ITransportable
    {
        public GameObject GetTarget()
        {
            return null;
        }
    }
}