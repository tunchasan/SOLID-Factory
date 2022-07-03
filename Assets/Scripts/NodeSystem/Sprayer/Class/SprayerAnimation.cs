using System;
using DG.Tweening;
using NodeSystem.Sprayer.Base;
using UnityEngine;

namespace NodeSystem.Sprayer.Class
{
    public class SprayerAnimation : SprayerAnimationBase
    {
        public override void Animate(Quaternion animateRotation, float duration, Action onSprayFrame)
        {
            animationTarget.DORotateQuaternion(animateRotation, duration / 2F).OnComplete(() =>
            {
                animationTarget.DOScaleX(.6F, duration / 2F).OnComplete(() =>
                {
                    animationTarget.DOScaleX(.5F, duration / 2F);
                });

                onSprayFrame?.Invoke();
                
                animationTarget.DOLocalRotate(Vector3.zero, duration / 2F);
            });
        }
    }
}