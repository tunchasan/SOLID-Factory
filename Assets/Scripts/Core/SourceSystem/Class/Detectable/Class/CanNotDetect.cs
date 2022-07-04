using Factorio.Core.SourceSystem.Class.Detectable.Base;
using UnityEngine;

namespace Factorio.Core.SourceSystem.Class.Detectable.Class
{
    public class CanNotDetect : IDetectable
    {
        public GameObject GetTarget()
        {
            return null;
        }
    }
}