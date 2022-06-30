using System;
using DG.Tweening;
using UnityEngine;

namespace NodeSystem
{
    public abstract class ProcessorAnimationBase : MonoBehaviour
    {
        [SerializeField] protected Transform animationTarget = null;
        [SerializeField] protected Ease easingType = Ease.OutExpo;
        
        public abstract void Animate(float duration, Action onComplete = null);
    }
}