using LocomotionSystem.Base;
using LocomotionSystem.Class;
using TankSystem.Base;
using TankSystem.Data;
using TankSystem.Units.PlacerUnit.Base;

namespace TankSystem.Class
{
    public class HeavyTank : TankBase
    {
        private LocomotionBase _locomotion = null;
        private PlacerUnitBase _placerUnit = null;
        
        #region Initializations
        public override void Initialize(TankData data)
        {
            base.Initialize(data);
            _locomotion = GetComponent<MobileLocomotion>();
            _placerUnit = GetComponentInChildren<PlacerUnitBase>();
            _placerUnit.Initialize(true);

            _locomotion.OnLocomotion += OnLocomotion;
            _locomotion.OnCancelledLocomotion += OnCancelledLocomotion;
        }

        protected virtual void OnDisable()
        {
            _locomotion.OnLocomotion -= OnLocomotion;
            _locomotion.OnCancelledLocomotion -= OnCancelledLocomotion;
        }

        #endregion

        protected virtual void OnLocomotion()
        {
            _placerUnit.Block();
        }

        protected virtual void OnCancelledLocomotion()
        {
            _placerUnit.UnBlock();
        }
    }
}