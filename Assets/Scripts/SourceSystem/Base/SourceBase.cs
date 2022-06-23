using ConveyorBeltSystem.Base;
using DetectorSystem.Base;
using GameEventsSystem;
using PlacerSystem.Base;
using SourceSystem.Class;
using StorageSystem.Base;
using UnityEngine;

namespace SourceSystem.Base
{
    public abstract class SourceBase : MonoBehaviour, ISource
    {
        [SerializeField] private CD_Source configData = null;
        protected IStorable Storable { get; set; } = null;
        protected IPlaceable Placeable { get; set; } = null;
        protected IDetectable Detectable { get; set; } = null;
        protected ITransportable Transportable { get; set; } = null;

        #region Behaviour
        public void SetBehaviour(CD_Source config)
        {
            configData = config;

            SetBehaviour();
        }

        protected virtual void SetBehaviour()
        {
            Detectable = configData.InitializeDetectableBehaviour(gameObject);
            Placeable = configData.InitializePlaceableBehaviour(gameObject);
            Storable = configData.InitializeStorableBehaviour(gameObject);
            Transportable = configData.InitializeTransportableBehaviour(gameObject);
        }

        public void SetBehaviour(IStorable storable, IPlaceable placeable, 
            IDetectable detectable, ITransportable transportable)
        {
            Storable = storable;
            Placeable = placeable;
            Detectable = detectable;
            Transportable = transportable;
        }
        
        #endregion
        
        public virtual IStorable IsStorable()
        {
            return Storable as CanStore;
        }
        
        public virtual IPlaceable IsPlaceable()
        {
            return Placeable as CanPlace;
        }
        public virtual IDetectable IsDetectable()
        {
            return Detectable as CanDetect;
        }
        public virtual ITransportable IsTransportable()
        {
            return Transportable as CanTransport;
        }
        public void SetVisual(Sprite sprite)
        {
            var visual = gameObject.GetComponentInChildren<SpriteRenderer>();
            if (visual)
                visual.sprite = preset.visual;
        }

        private void OnEnable()
        {
            GameEvents.StartEvent += SetBehaviour;
        }
        
        private void OnDisable()
        {
            GameEvents.StartEvent -= SetBehaviour;
        }
    }

    public class Triangle : SourceBase
    {
        protected override void SetBehaviour()
        {
            Storable = new CanStoreSingle();
        }
    }
}