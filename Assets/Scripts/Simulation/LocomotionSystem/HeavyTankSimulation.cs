using Factorio.Core.TankSystem.Class;
using Factorio.Core.TankSystem.Data;
using Factorio.Core.TankSystem.Units.PlacerUnit.Base;

namespace Factorio.Simulation.LocomotionSystem
{
    public class HeavyTankSimulation : HeavyTank
    {
        public override void Initialize(TankData data)
        {
            Locomotion = GetComponent<MobileLocomotionSimulation>();
            PlacerUnit = GetComponentInChildren<PlacerUnitBase>();
            PlacerUnit.Initialize(false);

            Locomotion.OnLocomotion += OnLocomotion;
            Locomotion.OnCancelledLocomotion += OnCancelledLocomotion;
        }
    }
}