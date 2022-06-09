using DetectorSystem.Base;
using LocomotionSystem;
using LocomotionSystem.Base;
using LocomotionSystem.Class;
using TankSystem.Base;
using TankSystem.Data;

namespace TankSystem.Class
{
    public class MobileTank : TankBase
    {
        private LocomotionBase _locomotion = null;
        private DetectorBase _detector = null;
        
        public override void Initialize(TankData data)
        {
            base.Initialize(data);
            _locomotion = GetComponent<MobileLocomotion>();
            _detector = GetComponentInChildren<DetectorBase>();
        }
    }
}