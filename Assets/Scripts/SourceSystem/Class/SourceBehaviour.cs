using DetectorSystem.Base;
using PlacerSystem.Base;
using SourceSystem.Base;
using SourceSystem.Class.Detectable.Base;
using SourceSystem.Class.Placeable.Base;
using SourceSystem.Class.Processable.Base;
using SourceSystem.Class.Storable.Base;
using SourceSystem.Class.Transportable.Base;
using StorageSystem.Base;
using UnityEngine;

namespace SourceSystem.Class
{
    public class SourceBehaviour : SourceBehaviourBase
    {
        public override void SetBehaviour(IStorable storable, IPlaceable placeable, IDetectable detectable, 
            ITransportable transportable, IProcessable processable)
        {
            Storable = storable;
            Placeable = placeable;
            Detectable = detectable;
            Transportable = transportable;
            Processable = processable;
        }
        public override void SetBehaviour(SourceConfigDataBase config, GameObject gameObject)
        {
            Detectable = config.InitializeDetectableBehaviour(gameObject);
            Placeable = config.InitializePlaceableBehaviour(gameObject);
            Storable = config.InitializeStorableBehaviour(gameObject);
            Transportable = config.InitializeTransportableBehaviour(gameObject);
            Processable = config.InitializeProcessableBehaviour(gameObject);
        }
    }
}