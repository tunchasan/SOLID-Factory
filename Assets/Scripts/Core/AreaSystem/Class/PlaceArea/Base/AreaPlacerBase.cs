using System;
using System.Collections.Generic;
using Factorio.Core.SourceSystem.Class.Placeable.Base;
using UnityEngine;

namespace Factorio.Core.AreaSystem.Class.PlaceArea.Base
{
    [RequireComponent(typeof(AreaPlacerAnimationBase))]
    public abstract class AreaPlacerBase : MonoBehaviour
    {
        protected AreaPlacerAnimationBase AreaPlacerAnimation = null;
        
        public readonly List<IPlaceable> PlacedElements = new();
        public virtual void Initialize()
        {
            AreaPlacerAnimation = GetComponent<AreaPlacerAnimationBase>();
        }
        public abstract void Place(IPlaceable element, Action<bool> onComplete = null);
    }
}