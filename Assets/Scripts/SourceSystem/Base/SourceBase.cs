using ConveyorBeltSystem.Base;
using DetectorSystem.Base;
using PlacerSystem.Base;
using StorageSystem.Base;
using StorageSystem.Utilities;
using UnityEngine;

namespace SourceSystem.Base
{
    public abstract class SourceBase : MonoBehaviour
    {
        protected IStorable Storable { get; set; } = null;
        protected IPlaceable Placeable { get; set; } = null;
        protected IDetectable Detectable { get; set; } = null;
        protected ITransportable Transportable { get; set; } = null;

        private void Awake()
        {
            SetBehaviour();
        }

        protected virtual void SetBehaviour()
        {
            Storable = new CanNotStorable(EntityType.Source);
            Placeable = new CanNotPlaceable();
            Detectable = new CanNotDetectable();
            Transportable = new CanTransportable(gameObject);
        }
    }

    public class CanTransportable : ITransportable
    {
        private readonly GameObject _target = null;
        public CanTransportable(GameObject target)
        {
            _target = target;
        }
        public GameObject GetTarget()
        {
            return _target;
        }
    }
    public class CanNotTransportable : ITransportable
    {
        public GameObject GetTarget()
        {
            return null;
        }
    }
    public class CanDetectable : IDetectable
    {
        private readonly GameObject _target = null;
        public CanDetectable(GameObject target)
        {
            _target = target;
        }
        public GameObject GetTarget()
        {
            return _target;
        }
    }
    public class CanNotDetectable : IDetectable
    {
        public GameObject GetTarget()
        {
            return null;
        }
    }
    public class CanPlaceable : IPlaceable
    {
        private readonly GameObject _target = null;
        public GameObject GetTarget()
        {
            return _target;
        }
        public void UnPossesBy()
        {
            _target.transform.SetParent(null);
        }
    }
    public class CanNotPlaceable : IPlaceable
    {
        public GameObject GetTarget()
        {
            return null;
        }
        public void UnPossesBy()
        {
            // no-op
        }
    }
    public class CanStorable : IStorable
    {
        private readonly GameObject _target = null;
        public EntityType Type { get; }
        public CanStorable(GameObject target, EntityType type)
        {
            _target = target;
            Type = type;
        }
        public GameObject GetTarget()
        {
            return _target;
        }
        public void PossesBy(Transform instigator)
        {
            _target.transform.SetParent(instigator);
        }
    }

    public class CanNotStorable : IStorable
    {
        public CanNotStorable(EntityType type)
        {
            Type = type;
        }
        public GameObject GetTarget()
        {
            return null;
        }
        public EntityType Type { get; }
        public void PossesBy(Transform instigator)
        {
            // no-op
        }
    }
}