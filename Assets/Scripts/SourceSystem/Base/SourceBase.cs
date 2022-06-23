using ConveyorBeltSystem.Base;
using DetectorSystem.Base;
using PlacerSystem.Base;
using SourceSystem.Class;
using StorageSystem.Base;
using UnityEngine;

namespace SourceSystem.Base
{
    public abstract class SourceBase : MonoBehaviour, ISource
    {
        [SerializeField] private SourceConfigDataBase configData = null;
        
        private SourceBehaviourBase _sourceBehaviour = null;
        private SourceVisualBase _sourceVisual = null;

        private void Awake()
        {
            Initialize();
        }
        protected virtual void Initialize()
        {
            _sourceBehaviour = new SourceBehaviour(configData, gameObject);
            _sourceVisual = GetComponent<SourceVisual>();
            _sourceVisual.SetVisual(configData.Visual);
        }
        public virtual IStorable IsStorable()
        {
            return _sourceBehaviour.Storable as CanStore;
        }
        public virtual IPlaceable IsPlaceable()
        {
            return _sourceBehaviour.Placeable as CanPlace;
        }
        public virtual IDetectable IsDetectable()
        {
            return _sourceBehaviour.Detectable as CanDetect;
        }
        public virtual ITransportable IsTransportable()
        {
            return _sourceBehaviour.Transportable as CanTransport;
        }
    }
}