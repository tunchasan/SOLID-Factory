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
            _storage.OnStore += OnStore;
        }

        private void OnDisable()
        {
            _storage.OnStore -= OnStore;
        }

        private void OnStore(IStorable storableElem)
        {
            _placer.OnReceiveElement(storableElem.GetTarget());
        }
    }
}