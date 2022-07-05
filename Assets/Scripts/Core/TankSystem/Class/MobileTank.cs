using Factorio.Core.DetectorSystem.Base;
using Factorio.Core.LocomotionSystem.Base;
using Factorio.Core.LocomotionSystem.Class;
using Factorio.Core.SourceSystem.Class.Detectable.Base;
using Factorio.Core.TankSystem.Base;
using Factorio.Core.TankSystem.Data;

namespace Factorio.Core.TankSystem.Class
{
    public class MobileTank : TankBase
    {
        protected LocomotionBase Locomotion = null;
        protected DetectorBase<IDetectable> Detector = null;
        
        public override void Initialize(TankData data)
        {
            base.Initialize(data);
            Locomotion = GetComponent<MobileLocomotion>();
            ((MobileLocomotion) Locomotion).SetMovementSpeed(data.movementSpeed);
            Detector = GetComponentInChildren<DetectorBase<IDetectable>>();
        }
    }
}