using UnityEngine;

namespace TankSystem
{
    public abstract class Tank : MonoBehaviour
    {
        protected abstract TankData Data { get; set; }

        public abstract void Initialize(TankData data);
    }
}