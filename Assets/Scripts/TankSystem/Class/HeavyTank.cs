using DetectorSystem.Base;
using DropSystem.Base;
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
        private DropperBase _dropper = null;
        
        public override void Initialize(TankData data)
        {
            base.Initialize(data);
            _locomotion = GetComponent<MobileLocomotion>();
            _detector = GetComponentInChildren<DetectorBase>();
            _storage = GetComponentInChildren<StorageBase>();
            _dropper = GetComponentInChildren<DropperBase>();
            _detector.OnDetectSomething += OnDetect;
            _dropper.OnDetectDropArea += OnDrop;
        }

        private void OnDisable()
        {
            _detector.OnDetectSomething -= OnDetect;
            _dropper.OnDetectDropArea -= OnDrop;
        }

        private void OnDetect(IDetectable target)
        {
            _storage.StoreElement(target as IStorable);
        }

        private void OnDrop()
        {
            _dropper.DropElements(_storage.Storages);
        }
    }
}