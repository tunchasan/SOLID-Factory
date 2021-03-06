using System;
using UnityEngine;

namespace Factorio.Core.NodeSystem.Sprayer.Base
{
    public abstract class SprayerAnimationBase : MonoBehaviour
    {
        [SerializeField] protected Transform animationTarget = null;

        public abstract void Animate(Quaternion animateRotation, float duration, Action onSprayFrame);
    }
}