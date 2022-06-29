using System;
using UnityEngine;

namespace NodeSystem
{
    public abstract class SprayerAnimationBase : MonoBehaviour
    {
        [SerializeField] protected Transform animationTarget = null;

        public abstract void Animate(Quaternion animateRotation, float duration, Action onSprayFrame);
    }
}