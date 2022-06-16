using DetectorSystem.Base;
using UnityEngine;

namespace SourceSystem.Class
{
    public class CanNotDetect : IDetectable
    {
        public GameObject GetTarget()
        {
            return null;
        }
    }
}