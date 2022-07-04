using Factorio.Core.SourceSystem.Class.Placeable.Base;
using UnityEngine;

namespace Factorio.Core.SourceSystem.Class.Placeable.Class
{
    public class CanNotPlace : IPlaceable
    {
        public GameObject GetTarget()
        {
            return null;
        }

        public void UnPossesBy()
        {
            // no-op
        }
    }
}