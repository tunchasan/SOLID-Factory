using SourceSystem.Class.Processable.Base;
using UnityEngine;

namespace SourceSystem.Class.Processable.Class
{
    public class CanNotProcess : IProcessable
    {
        public GameObject GetTarget()
        {
            return null;
        }
    }
}