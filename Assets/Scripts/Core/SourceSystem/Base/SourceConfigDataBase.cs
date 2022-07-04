using Factorio.Core.SourceSystem.Class.Detectable.Base;
using Factorio.Core.SourceSystem.Class.Placeable.Base;
using Factorio.Core.SourceSystem.Class.Processable.Base;
using Factorio.Core.SourceSystem.Class.Storable.Base;
using Factorio.Core.SourceSystem.Class.Transportable.Base;
using Factorio.Core.SourceSystem.Enums;
using UnityEngine;

namespace Factorio.Core.SourceSystem.Base
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