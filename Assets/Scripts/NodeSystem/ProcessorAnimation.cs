using System;
using DG.Tweening;
using UnityEngine;

namespace NodeSystem
{
    public class ProcessorAnimation : ProcessorAnimationBase
    {
        private Tween _animation = null;
        public override void Animate(float duration, Action onComplete = null)
        {
            if (_animation != null)
            {
                Debug.Log($"ProcessorAnimation :: Animation is not completed yet!");
                
                return;
            }
            
            _animation = animationTarget.DOScale(Vector3.one * 1.2F, duration / 2F).OnComplete(() =>
            {
                _animation = animationTarget.DOScale(Vector3.one, duration / 2F).SetEase(easingType)
                    .OnComplete(() =>
                    {
                        onComplete?.Invoke();

                        _animation = null;
                    });

            }).SetEase(easingType);
        }
    }
}