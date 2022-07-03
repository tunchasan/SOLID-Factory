using SourceSystem.Class.Detectable.Base;
using UnityEngine;

namespace SourceSystem.Class.Detectable.Class
{
    public class CanNotDetect : IDetectable
    {
        public GameObject GetTarget()
        {
            return null;
        }
    }
}