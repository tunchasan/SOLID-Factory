using System;
using UnityEngine;

namespace GameEventsSystem
{
    public class GameEvents : MonoBehaviour
    {
        public static Action AwakeEvent;
        public static Action StartEvent;
        public static Action BlockEvent;

        private void Awake()
        {
            AwakeEvent?.Invoke();
        }
        private void Start()
        {
            StartEvent?.Invoke();
        }
        public static void BlockGame()
        {
            BlockEvent?.Invoke();
        }
    }
}