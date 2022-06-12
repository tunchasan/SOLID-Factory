using System;
using UnityEngine;

namespace AreaSystem.Class.PlaceArea.Base
{
    public abstract class AreaPlacerAnimationBase : MonoBehaviour
    {
        public abstract void AnimatePlacing(Transform target, Action<bool> onComplete = null);
    }
}