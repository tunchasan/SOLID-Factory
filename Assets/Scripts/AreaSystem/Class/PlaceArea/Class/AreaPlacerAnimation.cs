using System;
using AreaSystem.Class.PlaceArea.Base;
using DG.Tweening;
using UnityEngine;

namespace AreaSystem.Class.PlaceArea.Class
{
    public class AreaPlacerAnimation : AreaPlacerAnimationBase
    {
        public override void AnimatePlacing(Transform target, Action<bool> onComplete = null)
        {
            target.DOMove(transform.position, .5F).OnComplete(()=> onComplete?.Invoke(true));
        }
    }
}