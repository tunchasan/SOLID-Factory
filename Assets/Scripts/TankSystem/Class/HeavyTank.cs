using DetectorSystem.Base;
using LocomotionSystem.Base;
using LocomotionSystem.Class;
using PlacerSystem.Base;
using StorageSystem.Base;
using TankSystem.Base;
using TankSystem.Data;

namespace TankSystem.Class
{
    public class HeavyTank : TankBase
    {
        private LocomotionBase _locomotion = null;
        private StorageBase _storage = null;
        private PlacerBase _placer = null;
        
        public override void Initialize(TankData data)
        {
            base.Initialize(data);
            _locomotion = GetComponent<MobileLocomotion>();
            _storage = GetComponentInChildren<StorageBase>();
            _placer = GetComponentInChildren<PlacerBase>();
            _placer.Initialize();
            _storage.Initialize();
            _placer.PlaceableAreaDetector.OnDetectSomething += OnPlace;
        }

        private void OnDisable()
        {
            _placer.PlaceableAreaDetector.OnDetectSomething -= OnPlace;
        }

        private void OnPlace(IDetectable placeableArea)
        {
            _placer.PlaceElements(_storage.Storages);
        }
    }
}