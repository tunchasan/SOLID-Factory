using Factorio.Core.SourceSystem.Class;
using Factorio.Core.SourceSystem.Class.Detectable.Base;
using Factorio.Core.SourceSystem.Class.Detectable.Class;
using Factorio.Core.SourceSystem.Class.Placeable.Base;
using Factorio.Core.SourceSystem.Class.Placeable.Class;
using Factorio.Core.SourceSystem.Class.Processable.Base;
using Factorio.Core.SourceSystem.Class.Processable.Class;
using Factorio.Core.SourceSystem.Class.Storable.Base;
using Factorio.Core.SourceSystem.Class.Transportable.Base;
using Factorio.Core.SourceSystem.Class.Transportable.Class;
using UnityEngine;

namespace Factorio.Core.SourceSystem.Base
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