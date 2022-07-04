using System;
using DG.Tweening;
using Factorio.Core.AreaSystem.Class.PlaceArea.Base;
using UnityEngine;

namespace Factorio.Core.AreaSystem.Class.PlaceArea.Class
{
    public class AreaPlacerAnimation : AreaPlacerAnimationBase
    {
        public override void AnimatePlacing(Transform target, Action<bool> onComplete = null)
        {
            target.DOMove(transform.position, 2F).OnComplete(()=> onComplete?.Invoke(true));
        }
    }
}