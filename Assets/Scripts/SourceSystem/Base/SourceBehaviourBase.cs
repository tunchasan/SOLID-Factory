using ConveyorBeltSystem.Base;
using DetectorSystem.Base;
using PlacerSystem.Base;
using SourceSystem.Class;
using StorageSystem.Base;
using UnityEngine;

namespace SourceSystem.Base
{
    public  class SourceBehaviourBase
    {
        public IStorable Storable { get; protected set; } = null;
        public IPlaceable Placeable { get; protected set; } = null;
        public IDetectable Detectable { get; protected set; } = null;
        public ITransportable Transportable { get; protected set; } = null;

        public SourceBehaviourBase(SourceConfigDataBase config, GameObject gameObject)
        {
            SetBehaviour(config, gameObject);
        }
        
        public virtual void SetBehaviour(IStorable storable, IPlaceable placeable, 
            IDetectable detectable, ITransportable transportable)
        {
            Storable = storable;
            Placeable = placeable;
            Detectable = detectable;
            Transportable = transportable;
        }

        private void SetBehaviour(SourceConfigDataBase config, GameObject gameObject)
        {
            Detectable = config.InitializeDetectableBehaviour(gameObject);
            Placeable = config.InitializePlaceableBehaviour(gameObject);
            Storable = config.InitializeStorableBehaviour(gameObject);
            Transportable = config.InitializeTransportableBehaviour(gameObject);
        }
    }
}