using Factorio.Core.SourceSystem.Class.Processable.Base;
using UnityEngine;

namespace Factorio.Core.SourceSystem.Class.Processable.Class
{
    public class CanNotProcess : IProcessable
    {
        public GameObject GetTarget()
        {
            return null;
        }
    }
}