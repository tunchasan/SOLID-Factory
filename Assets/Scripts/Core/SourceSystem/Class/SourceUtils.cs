using Factorio.Core.SourceSystem.Base;
using Factorio.Core.SourceSystem.Class.Detectable.Base;
using Factorio.Core.SourceSystem.Class.Placeable.Base;
using Factorio.Core.SourceSystem.Class.Processable.Base;
using Factorio.Core.SourceSystem.Class.Storable.Base;
using Factorio.Core.SourceSystem.Class.Transportable.Base;
using UnityEngine;

namespace Factorio.Core.SourceSystem.Class
{
    public static class SourceUtils
    {
        public static bool TryGetStorable(this GameObject target, out IStorable storable)
        {
            storable = target.TryGetComponent(out ISource source) ? 
                source.IsStorable(): 
                target.GetComponent<IStorable>();
            return storable != null;
        }
        
        public static bool TryGetPlaceable(this GameObject target, out IPlaceable placeable)
        {
            placeable = target.TryGetComponent(out ISource source) ? 
                source.IsPlaceable(): 
                target.GetComponent<IPlaceable>();
            return placeable != null;
        }
        
        public static bool TryGetTransportable(this GameObject target, out ITransportable transportable)
        {
            transportable = target.TryGetComponent(out ISource source) ? 
                source.IsTransportable(): 
                target.GetComponent<ITransportable>();
            return transportable != null;
        }
        
        public static bool TryGetDetectable(this GameObject target, out IDetectable detectable)
        {
            detectable = target.TryGetComponent(out ISource source) ? 
                source.IsDetectable(): 
                target.GetComponent<IDetectable>();
            return detectable != null;
        }
        
        public static bool TryGetProcessable(this GameObject target, out IProcessable processable)
        {
            processable = target.TryGetComponent(out ISource source) ? 
                source.IsProcessable(): 
                target.GetComponent<IProcessable>();
            return processable != null;
        }
    }
}