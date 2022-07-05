using Factorio.Core.DetectorSystem.Base;
using Factorio.Core.LocomotionSystem.Base;
using Factorio.Core.SourceSystem.Class.Detectable.Base;
using Factorio.Core.TankSystem.Base;
using Factorio.Core.TankSystem.Data;

namespace Factorio.Simulation.LocomotionSystem
{
    public class MobileTankSimulation : TankBase
    {
        private LocomotionBase _locomotion = null;
        private DetectorBase<IDetectable> _detector = null;
        
        public override void Initialize(TankData data)
        {
            base.Initialize(data);
            _locomotion = GetComponent<MobileLocomotionSimulation>();
            ((MobileLocomotionSimulation) _locomotion).SetMovementSpeed(data.movementSpeed);
            _detector = GetComponentInChildren<DetectorBase<IDetectable>>();
        }
    }
}