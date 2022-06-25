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
        public static IStorable ConvertToStorable(this GameObject target)
        {
            return target.TryGetComponent(out ISource source) ? 
                source.IsStorable(): 
                target.GetComponent<IStorable>();
        }
        
        public static IPlaceable ConvertToPlaceable(this GameObject target)
        {
            return target.TryGetComponent(out ISource source) ? 
                source.IsPlaceable(): 
                target.GetComponent<IPlaceable>();
        }
        
        public static ITransportable ConvertToTransportable(this GameObject target)
        {
            return target.TryGetComponent(out ISource source) ? 
                source.IsTransportable(): 
                target.GetComponent<ITransportable>();
        }
        
        public static IDetectable ConvertToDetectable(this GameObject target)
        {
            return target.TryGetComponent(out ISource source) ? 
                source.IsDetectable(): 
                target.GetComponent<IDetectable>();
        }
    }
}