using DetectorSystem.Base;
using PlacerSystem.Base;
using SourceSystem.Class;
using SourceSystem.Class.Detectable.Base;
using SourceSystem.Class.Placeable.Base;
using SourceSystem.Class.Processable.Base;
using SourceSystem.Class.Storable.Base;
using SourceSystem.Class.Transportable.Base;
using SourceSystem.Enums;
using StorageSystem.Base;
using UnityEngine;

namespace SourceSystem.Base
{
    public abstract class SourceConfigDataBase : ScriptableObject
    {
        [SerializeField] protected DetectableType detectType;
        [SerializeField] protected PlaceableType placeType;
        [SerializeField] protected StorableType storeType;
        [SerializeField] protected TransportableType transportType;
        [SerializeField] protected ProcessableType processableType;
        [SerializeField] protected Sprite visual = null;
        public abstract Sprite Visual { get; protected set; }
        public abstract IDetectable InitializeDetectableBehaviour(GameObject gameObject);
        public abstract IStorable InitializeStorableBehaviour(GameObject gameObject);
        public abstract IPlaceable InitializePlaceableBehaviour(GameObject gameObject);
        public abstract ITransportable InitializeTransportableBehaviour(GameObject gameObject);
        public abstract IProcessable InitializeProcessableBehaviour(GameObject gameObject);
    }
}