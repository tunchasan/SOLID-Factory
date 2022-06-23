using System;
using System.Collections;
using System.Collections.Generic;
using BlockSystem;
using DG.Tweening;
using GameEventsSystem;
using NodeSystem;
using SourceSystem.Base;
using UnityEngine;

namespace ConveyorBeltSystem.Base
{
    public class ConveyorBeltBase : BlockableMonobehaviour, INode
    {
        [SerializeField] protected Transform StartLocation = null;
        [SerializeField] protected Transform EndLocation = null;

        protected bool IsBusy = false;
        protected float TransportSpeed = 1F;
        [SerializeField] protected bool isMultipleTransport = false;

        public List<GameObject> list = new();

        private float _conveyorLength = 0F;

        private void StartSystem()
        {
            Initialize(false);

            StartCoroutine(ProcessTransport());
        }

        public override void Initialize(bool hasBlocked)
        {
            base.Initialize(hasBlocked);
            CalculateLength();
        }
        private void CalculateLength()
        {
            _conveyorLength = Vector3.Distance(StartLocation.position, EndLocation.position);
        }
        protected bool CanTransport()
        {
            if (HasBlocked)
            {
                Debug.Log($"Transport operation has blocked in {name}");

                return false;
            }

            return !IsBusy;
        }

        public bool Transport(Transform target, Action onComplete = null)
        {
            if(!CanTransport()) return false;
            
            IsBusy = true;

            var placeEstimatedTime = TransportSpeed / 2F;
            var estimatedTime = _conveyorLength * TransportSpeed;
            
            target.DOMove(StartLocation.position, placeEstimatedTime).OnComplete(() =>
            {
                target.DOMove(EndLocation.position, estimatedTime).OnComplete(() =>
                {
                    onComplete?.Invoke();
                        
                    IsBusy = false;

                }).SetEase(Ease.Linear);
            });

            if (isMultipleTransport)
            {
                DOVirtual.DelayedCall(placeEstimatedTime, () => IsBusy = false);
            }

            return true;
        }

        private IEnumerator ProcessTransport()
        {
            while (true)
            {
                if (list.Count > 0)
                {
                    var target = list[0];
                    
                    var status = Transport(target.transform);

                    if (status)
                    {
                        list.Remove(target);
                    }
                }
                
                yield return new WaitForSeconds(.25F);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var transportable = other.GetComponent<ISource>()?.IsTransportable();
            
            if (transportable != null && transportable.GetTarget() != null)
            {
                if (!list.Contains(transportable.GetTarget().gameObject))
                {
                    list.Add(transportable.GetTarget().gameObject);
                }
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out INode nextNode))
            {
                ValidateNode(nextNode);
            }
        }

        private void OnEnable()
        {
            GameEvents.StartEvent += StartSystem;
        }

        private void OnDisable()
        {
            GameEvents.StartEvent -= StartSystem;
        }

        #region NodeSystem

        public INode NextNode { get; private set; } = null;

        private void Update()
        {
            Debug.Log(NextNode);
        }

        public void Input()
        {
            throw new NotImplementedException();
        }

        public void Process()
        {
            throw new NotImplementedException();
        }

        public void Output()
        {
            throw new NotImplementedException();
        }

        public void ValidateNode(INode nextNode)
        {
            NextNode = nextNode;
        }

        #endregion
    }

    public interface ITransportable
    {
        GameObject GetTarget();
    }
}