using System;
using ConveyorBeltSystem.Base;
using DetectorSystem.Base;
using PlacerSystem.Base;
using SourceSystem.Enums;
using StorageSystem.Base;
using StorageSystem.Utilities;
using UnityEngine;

namespace SourceSystem.Class
{
    [CreateAssetMenu]
    public class SourceConfigData : ScriptableObject
    {
        [SerializeField]
        private DetectableType detectType;
        [SerializeField]
        private PlaceableType placeType;
        [SerializeField]
        private StorableType storeType;
        [SerializeField]
        private TransportableType transportType;
        public Sprite visual;

        public IDetectable InitializeDetectableBehaviour(GameObject gameObject)
        {
            return detectType switch
            {
                DetectableType.CanDetect => new CanDetect(gameObject),
                DetectableType.CanNotDetect => new CanNotDetect(),
                _ => throw new NotImplementedException($"{detectType} is not implemented by {GetType()}")
            };
        }
        public IStorable InitializeStorableBehaviour(GameObject gameObject)
        {
            return storeType switch
            {
                StorableType.CanStoreSingle => new CanStoreSingle(gameObject, EntityType.Source),
                StorableType.CanStoreMultiple => new CanStoreMultiple(gameObject, EntityType.Source),
                StorableType.CanNotStore => new CanNotStore(EntityType.Source),
                _ => throw new NotImplementedException($"{storeType} is not implemented by {GetType()}")
            };
        }
        public IPlaceable InitializePlaceableBehaviour(GameObject gameObject)
        {
            return placeType switch
            {
                PlaceableType.CanPlace => new CanPlace(gameObject),
                PlaceableType.CanNotPlace => new CanNotPlace(),
                _ => throw new NotImplementedException($"{placeType} is not implemented by {GetType()}")
            };
        }
        public ITransportable InitializeTransportableBehaviour(GameObject gameObject)
        {
            return transportType switch
            {
                TransportableType.CanTransport => new CanTransport(gameObject),
                TransportableType.CanNotTransport => new CanNotTransport(),
                _ => throw new NotImplementedException($"{transportType} is not implemented by {GetType()}")
            };
        }
    }
}