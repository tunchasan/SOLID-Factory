using System;
using System.Collections;
using System.Collections.Generic;
using DetectorSystem.Class;
using DG.Tweening;
using PlacerSystem.Base;
using UnityEngine;

namespace NodeSystem
{
    [RequireComponent(typeof(SprayerAreaBase))]
    public class SprayerNode : MonoBehaviour, INode<IPlaceable>
    {
        public Queue<IPlaceable> Elements { get; protected set; } = new();
        public Action<INode, List<GameObject>> OnOutput { get; set; }
        public float Duration { get; protected set; } = .5F;
        
        private SprayerAreaBase _area = null;
        private SprayerAnimationBase _animation = null;
        private YieldInstruction _waitForSeconds;

        public void InitializeNode()
        {
            StartCoroutine(Process());
            _waitForSeconds = new WaitForSeconds(Duration);

            _area = GetComponent<SprayerAreaBase>();
            if (_area == null)
                _area = gameObject.AddComponent<CircleSprayerArea>();
            
            _animation = GetComponent<SprayerAnimationBase>();
            if (_animation == null)
                _animation = gameObject.AddComponent<SprayerAnimation>();
        }
        public IEnumerable<GameObject> Input(IEnumerable<GameObject> elements)
        {
            var notSuitableElements = new List<GameObject>();

            foreach (var element in elements)
            {
                if (element.TryGetPlaceable(out var placeable))
                {
                    if (!Elements.Contains(placeable))
                    {
                        Elements.Enqueue(placeable);
                    }
                }

                else
                {
                    notSuitableElements.Add(element);
                }
            }

            Debug.Log($"PlaceableAreaNode :: Total inputs count : {Elements.Count}");

            return notSuitableElements;
        }
        public IEnumerator Process()
        {
            Transform targetTransform;
            Quaternion targetRotation;
            Vector2 direction;
            float angle = 0;

            while (true)
            {
                IPlaceable processingElement = null;
                
                if (Elements.Count > 0)
                {
                    processingElement = Elements.Dequeue();

                    targetTransform = processingElement.GetTarget().transform;
                    direction = _area.SprayPosition() - transform.position;
                    angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
                    targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    
                     _animation.Animate(targetRotation, Duration, () =>
                     {
                         targetTransform.DOMove(_area.SprayPosition(), Duration)
                             .SetEase(Ease.OutExpo);

                     });
                }

                yield return _waitForSeconds;

                if (processingElement != null)
                {
                    Debug.Log($"PlaceableAreaNode :: {processingElement} element is processed");
                    
                    Output(processingElement.GetTarget());
                }
            }
        }
        public void Output(GameObject output)
        {
            Debug.Log($"PlaceableAreaNode :: Remained element's count is {Elements.Count}");

            OnOutput?.Invoke(this, new List<GameObject>{output});
        }
    }
}