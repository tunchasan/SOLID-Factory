using ConveyorBeltSystem.Base;
using DetectorSystem.Base;
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
        private void Start()
        {
            InitializeBehaviour();
        }
        private void InitializeBehaviour()
        {
            switch (preset.detectType)
            {
                case DetectableType.CanDetect:
                    Detectable = new CanDetect(gameObject);
                    break;
                case DetectableType.CanNotDetect:
                    Detectable = new CanNotDetect();
                    break;
            }

            switch (preset.placeType)
            {
                case PlaceableType.CanPlace:
                    Placeable = new CanPlace();
                    break;
                case PlaceableType.CanNotPlace:
                    Placeable = new CanNotPlace();
                    break;
            }

            switch (preset.storeType)
            {
                case StorableType.CanStoreSingle:
                    Storable = new CanStoreSingle(gameObject, EntityType.Source);
                    break;
                case StorableType.CanStoreMultiple:
                    Storable = new CanStoreMultiple(gameObject, EntityType.Source);
                    break;
                case StorableType.CanNotStore:
                    Storable = new CanNotStore(EntityType.Source);
                    break;
            }

            switch (preset.transportType)
            {
                case TransportableType.CanTransport:
                    Transportable = new CanTransport(gameObject);
                    break;
                case TransportableType.CanNotTransport:
                    Transportable = new CanNotTransport();
                    break;
            }
        }
        public void SetBehaviour(IStorable store, IPlaceable place, 
            IDetectable detect, ITransportable transport)
        {
            Storable = store;
            Placeable = place;
            Detectable = detect;
            Transportable = transport;
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
    }
}