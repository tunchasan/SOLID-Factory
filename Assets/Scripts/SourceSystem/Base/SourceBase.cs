using ConveyorBeltSystem.Base;
using DetectorSystem.Base;
using GameEventsSystem;
using PlacerSystem.Base;
using SourceSystem.Class;
using SourceSystem.Enums;
using StorageSystem.Base;
using StorageSystem.Utilities;
using UnityEngine;

namespace SourceSystem.Base
{
    public abstract class SourceBase : MonoBehaviour, ISource
    {
        [SerializeField] private SourcePreset preset = null;
        protected IStorable Storable { get; set; } = null;
        protected IPlaceable Placeable { get; set; } = null;
        protected IDetectable Detectable { get; set; } = null;
        protected ITransportable Transportable { get; set; } = null;

        #region Behaviour
        private void InitializeBehaviour()
        {
            var target = gameObject;
            Detectable = preset.detectType switch
            {
                DetectableType.CanDetect => new CanDetect(target),
                DetectableType.CanNotDetect => new CanNotDetect(),
                _ => Detectable
            };

            Placeable = preset.placeType switch
            {
                PlaceableType.CanPlace => new CanPlace(target),
                PlaceableType.CanNotPlace => new CanNotPlace(),
                _ => Placeable
            };

            Storable = preset.storeType switch
            {
                StorableType.CanStoreSingle => new CanStoreSingle(target, EntityType.Source),
                StorableType.CanStoreMultiple => new CanStoreMultiple(target, EntityType.Source),
                StorableType.CanNotStore => new CanNotStore(EntityType.Source),
                _ => Storable
            };

            Transportable = preset.transportType switch
            {
                TransportableType.CanTransport => new CanTransport(target),
                TransportableType.CanNotTransport => new CanNotTransport(),
                _ => Transportable
            };
            
            SetVisual(preset.visual);
        }
        public void SetBehaviour(SourcePreset sourcePreset)
        {
            preset = sourcePreset;
            InitializeBehaviour();
        }
        #endregion
        
        public virtual IStorable IsStorable()
        {
            return Storable;
        }
        public virtual IPlaceable IsPlaceable()
        {
            return Placeable;
        }
        public virtual IDetectable IsDetectable()
        {
            return Detectable;
        }
        public virtual ITransportable IsTransportable()
        {
            return Transportable;
        }
        public void SetVisual(Sprite sprite)
        {
            var visual = gameObject.GetComponentInChildren<SpriteRenderer>();
            if (visual)
                visual.sprite = preset.visual;
        }

        private void OnEnable()
        {
            GameEvents.StartEvent += InitializeBehaviour;
        }
        
        private void OnDisable()
        {
            GameEvents.StartEvent -= InitializeBehaviour;
        }
    }
}