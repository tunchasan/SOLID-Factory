using DetectorSystem.Base;
using LocomotionSystem;
using LocomotionSystem.Base;
using LocomotionSystem.Class;
using StorageSystem.Base;
using TankSystem.Base;
using TankSystem.Data;

namespace TankSystem.Class
{
    public class HeavyTank : TankBase
    {
        private LocomotionBase _locomotion = null;
        private DetectorBase _detector = null;
        private StorageBase _storage = null;
        
        public override void Initialize(TankData data)
        {
            base.Initialize(data);
            _locomotion = GetComponent<MobileLocomotion>();
            _detector = GetComponentInChildren<DetectorBase>();
            _storage = GetComponentInChildren<StorageBase>();
            _detector.OnDetectSomething += OnDetect;
        }

        private void OnDisable()
        {
            _detector.OnDetectSomething -= OnDetect;
        }

        private void OnDetect(IDetectable target)
        {
            _storage.StoreElement(target as IStorable);
        }
    }
}