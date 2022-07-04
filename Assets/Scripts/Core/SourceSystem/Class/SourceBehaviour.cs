using Factorio.Core.SourceSystem.Base;
using Factorio.Core.SourceSystem.Class.Detectable.Base;
using Factorio.Core.SourceSystem.Class.Placeable.Base;
using Factorio.Core.SourceSystem.Class.Processable.Base;
using Factorio.Core.SourceSystem.Class.Storable.Base;
using Factorio.Core.SourceSystem.Class.Transportable.Base;
using UnityEngine;

namespace Factorio.Core.SourceSystem.Class
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