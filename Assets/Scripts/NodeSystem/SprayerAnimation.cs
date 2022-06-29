using System;
using DG.Tweening;
using UnityEngine;

namespace NodeSystem
{
    public class SprayerAnimation : SprayerAnimationBase
    {
        public override void Animate(Quaternion animateRotation, float duration, Action onSprayFrame)
        {
            animationTarget.DORotateQuaternion(animateRotation, duration / 2F).OnComplete(() =>
            {
                // TODO : Animate with Animator
                animationTarget.DOScaleX(.6F, duration / 2F).OnComplete(() =>
                {
                    animationTarget.DOScaleX(.5F, duration / 2F);
                });
                /////////////////////////////////

                onSprayFrame?.Invoke();
                
                animationTarget.DOLocalRotate(Vector3.zero, duration / 2F);
            });
        }
    }
}