using ConveyorBeltSystem.Base;
using DetectorSystem.Base;
using PlacerSystem.Base;
using SourceSystem.Enums;
using StorageSystem.Base;
using UnityEngine;

namespace SourceSystem.Class
{
    public abstract class SourceConfigDataBase : ScriptableObject
    {
        [SerializeField] protected DetectableType detectType;
        [SerializeField] protected PlaceableType placeType;
        [SerializeField] protected StorableType storeType;
        [SerializeField] protected TransportableType transportType;
        [SerializeField] protected Sprite visual = null;
        public abstract Sprite Visual { get; protected set; }
        public abstract IDetectable InitializeDetectableBehaviour(GameObject gameObject);
        public abstract IStorable InitializeStorableBehaviour(GameObject gameObject);
        public abstract IPlaceable InitializePlaceableBehaviour(GameObject gameObject);
        public abstract ITransportable InitializeTransportableBehaviour(GameObject gameObject);
    }
}