using DetectorSystem;
using LocomotionSystem;
using TankSystem.Base;
using TankSystem.Data;

namespace TankSystem.Class
{
    public class StableTank : TankBase
    {
        private LocomotionBase _locomotion = null;
        private DetectorBase _detector = null;
        
        public override void Initialize(TankData data)
        {
            base.Initialize(data);
            _locomotion = GetComponent<StableLocomotionBase>();
            _detector = GetComponentInChildren<DetectorBase>();
        }
    }
}