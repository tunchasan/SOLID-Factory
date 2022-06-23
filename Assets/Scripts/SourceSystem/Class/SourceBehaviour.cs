using ConveyorBeltSystem.Base;
using DetectorSystem.Base;
using PlacerSystem.Base;
using SourceSystem.Base;
using StorageSystem.Base;
using UnityEngine;

namespace SourceSystem.Class
{
    public class SourceBehaviour : SourceBehaviourBase
    {
        public override void SetBehaviour(IStorable storable, IPlaceable placeable, IDetectable detectable, ITransportable transportable)
        {
            Storable = storable;
            Placeable = placeable;
            Detectable = detectable;
            Transportable = transportable;
        }
        public override void SetBehaviour(SourceConfigDataBase config, GameObject gameObject)
        {
            Detectable = config.InitializeDetectableBehaviour(gameObject);
            Placeable = config.InitializePlaceableBehaviour(gameObject);
            Storable = config.InitializeStorableBehaviour(gameObject);
            Transportable = config.InitializeTransportableBehaviour(gameObject);
        }
    }
}