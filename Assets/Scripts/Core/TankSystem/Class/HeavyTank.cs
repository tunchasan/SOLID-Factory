using Factorio.Core.LocomotionSystem.Base;
using Factorio.Core.LocomotionSystem.Class;
using Factorio.Core.TankSystem.Base;
using Factorio.Core.TankSystem.Data;
using Factorio.Core.TankSystem.Units.PlacerUnit.Base;

namespace Factorio.Core.TankSystem.Class
{
    public class HeavyTank : TankBase
    {
        protected LocomotionBase Locomotion = null;
        protected PlacerUnitBase PlacerUnit = null;
        
        #region Initializations
        public override void Initialize(TankData data)
        {
            base.Initialize(data);
            Locomotion = GetComponent<MobileLocomotion>();
            PlacerUnit = GetComponentInChildren<PlacerUnitBase>();
            PlacerUnit.Initialize(false);

            Locomotion.OnLocomotion += OnLocomotion;
            Locomotion.OnCancelledLocomotion += OnCancelledLocomotion;
        }

        protected virtual void OnDisable()
        {
            Locomotion.OnLocomotion -= OnLocomotion;
            Locomotion.OnCancelledLocomotion -= OnCancelledLocomotion;
        }

        #endregion

        protected virtual void OnLocomotion()
        {
            PlacerUnit.Block();
        }

        protected virtual void OnCancelledLocomotion()
        {
            PlacerUnit.UnBlock();
        }
    }
}