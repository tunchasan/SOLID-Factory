using DetectorSystem.Base;
using LocomotionSystem.Base;
using LocomotionSystem.Class;
using SourceSystem.Class.Detectable.Base;
using TankSystem.Base;
using TankSystem.Data;

namespace TankSystem.Class
{
    public class MobileTank : TankBase
    {
        private LocomotionBase _locomotion = null;
        private DetectorBase<IDetectable> _detector = null;
        
        public override void Initialize(TankData data)
        {
            base.Initialize(data);
            _locomotion = GetComponent<MobileLocomotion>();
            _detector = GetComponentInChildren<DetectorBase<IDetectable>>();
        }
    }
}