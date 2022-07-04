using Factorio.Core.DetectorSystem.Base;
using Factorio.Core.LocomotionSystem.Base;
using Factorio.Core.LocomotionSystem.Class;
using Factorio.Core.SourceSystem.Class.Detectable.Base;
using Factorio.Core.TankSystem.Base;
using Factorio.Core.TankSystem.Data;

namespace Factorio.Core.TankSystem.Class
{
    public class StableTank : TankBase
    {
        private LocomotionBase _locomotion = null;
        private DetectorBase<IDetectable> _detector = null;
        
        public override void Initialize(TankData data)
        {
            base.Initialize(data);
            _locomotion = GetComponent<StableLocomotion>();
            _detector = GetComponentInChildren<DetectorBase<IDetectable>>();
        }
    }
}