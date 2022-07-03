using System;
using DetectorSystem.Base;
using PlacerSystem.Base;
using SourceSystem.Base;
using SourceSystem.Class.Detectable.Base;
using SourceSystem.Class.Detectable.Class;
using SourceSystem.Class.Placeable.Base;
using SourceSystem.Class.Placeable.Class;
using SourceSystem.Class.Processable.Base;
using SourceSystem.Class.Processable.Class;
using SourceSystem.Class.Storable.Base;
using SourceSystem.Class.Storable.Class;
using SourceSystem.Class.Transportable.Base;
using SourceSystem.Class.Transportable.Class;
using SourceSystem.Enums;
using StorageSystem.Base;
using StorageSystem.Utilities;
using UnityEngine;

namespace SourceSystem.Class
{
    [CreateAssetMenu(menuName = "Source/ConfigData", fileName = "SourceConfigData", order = 0)]
    public class SourceConfigData : SourceConfigDataBase
    {
        public override Sprite Visual
        {
            get => visual;
            protected set => visual = value;
        }
        public override IDetectable InitializeDetectableBehaviour(GameObject gameObject)
        {
            return detectType switch
            {
                DetectableType.CanDetect => new CanDetect(gameObject),
                DetectableType.CanNotDetect => new CanNotDetect(),
                _ => throw new NotImplementedException($"{detectType} is not implemented by {GetType()}")
            };
        }
        public override IStorable InitializeStorableBehaviour(GameObject gameObject)
        {
            return storeType switch
            {
                StorableType.CanStoreSingle => new CanStoreSingle(gameObject, EntityType.Source),
                StorableType.CanStoreMultiple => new CanStoreMultiple(gameObject, EntityType.Source),
                StorableType.CanNotStore => new CanNotStore(EntityType.Source),
                _ => throw new NotImplementedException($"{storeType} is not implemented by {GetType()}")
            };
        }
        public override IPlaceable InitializePlaceableBehaviour(GameObject gameObject)
        {
            return placeType switch
            {
                PlaceableType.CanPlace => new CanPlace(gameObject),
                PlaceableType.CanNotPlace => new CanNotPlace(),
                _ => throw new NotImplementedException($"{placeType} is not implemented by {GetType()}")
            };
        }
        public override ITransportable InitializeTransportableBehaviour(GameObject gameObject)
        {
            return transportType switch
            {
                TransportableType.CanTransport => new CanTransport(gameObject),
                TransportableType.CanNotTransport => new CanNotTransport(),
                _ => throw new NotImplementedException($"{transportType} is not implemented by {GetType()}")
            };
        }

        public override IProcessable InitializeProcessableBehaviour(GameObject gameObject)
        {
            return processableType switch
            {
                ProcessableType.CanProcess => new CanProcess(gameObject),
                ProcessableType.CanNotProcess => new CanNotProcess(),
                _ => throw new NotImplementedException($"{processableType} is not implemented by {GetType()}")
            };
        }
    }
}