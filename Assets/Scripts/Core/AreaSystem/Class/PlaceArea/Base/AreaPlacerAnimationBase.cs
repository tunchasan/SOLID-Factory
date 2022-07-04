using System;
using UnityEngine;

namespace Factorio.Core.AreaSystem.Class.PlaceArea.Base
{
    public abstract class AreaPlacerAnimationBase : MonoBehaviour
    {
        public abstract void AnimatePlacing(Transform target, Action<bool> onComplete = null);
    }
}