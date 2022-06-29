using UnityEngine;

namespace SourceSystem.Class
{
    public class CanNotProcess : IProcessable
    {
        public GameObject GetTarget()
        {
            return null;
        }
    }
}