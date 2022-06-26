using ConveyorBeltSystem.Base;
using DetectorSystem.Base;
using PlacerSystem.Base;
using SourceSystem.Base;
using StorageSystem.Base;
using UnityEngine;

namespace DetectorSystem.Class
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
    }
}