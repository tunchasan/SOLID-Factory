using DetectorSystem.Base;
using PlacerSystem.Base;
using SourceSystem.Class;
using SourceSystem.Class.Detectable.Base;
using SourceSystem.Class.Detectable.Class;
using SourceSystem.Class.Placeable.Base;
using SourceSystem.Class.Placeable.Class;
using SourceSystem.Class.Processable.Base;
using SourceSystem.Class.Processable.Class;
using SourceSystem.Class.Storable.Base;
using SourceSystem.Class.Transportable.Base;
using SourceSystem.Class.Transportable.Class;
using StorageSystem.Base;
using UnityEngine;

namespace SourceSystem.Base
{
    public abstract class SourceBase : MonoBehaviour, ISource
    {
        [SerializeField] private SourceConfigDataBase configData = null;
        
        private SourceBehaviourBase _sourceBehaviour = null;
        private SourceVisualBase _sourceVisual = null;
        public SourceConfigDataBase ConfigData => configData;

        private void Awake()
        {
            Initialize();
        }
        protected virtual void Initialize()
        {
            _sourceBehaviour = new SourceBehaviour();
            _sourceVisual = GetComponent<SourceVisual>();
            _sourceBehaviour.SetBehaviour(configData, gameObject);
            _sourceVisual.SetVisual(configData.Visual);
        }
        public virtual void UpdateBehaviour(SourceConfigDataBase config)
        {
            configData = config;
            _sourceBehaviour.SetBehaviour(configData, gameObject);
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
        public IProcessable IsProcessable()
        {
            return _sourceBehaviour.Processable as CanProcess;
        }
    }
} 