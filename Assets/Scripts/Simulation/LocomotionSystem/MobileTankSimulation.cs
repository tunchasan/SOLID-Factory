using Factorio.Core.DetectorSystem.Base;
using Factorio.Core.SourceSystem.Class.Detectable.Base;
using Factorio.Core.TankSystem.Class;
using Factorio.Core.TankSystem.Data;

namespace Factorio.Simulation.LocomotionSystem
{
    public class MobileTankSimulation : MobileTank
    {
        public override void Initialize(TankData data)
        {
            Locomotion = GetComponent<MobileLocomotionSimulation>();
            ((MobileLocomotionSimulation) Locomotion).SetMovementSpeed(data.movementSpeed);
            Detector = GetComponentInChildren<DetectorBase<IDetectable>>();
        }
    }
}