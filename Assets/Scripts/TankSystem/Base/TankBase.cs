using TankSystem.Data;
using UnityEngine;
using Zenject;

namespace TankSystem.Base
{
    public abstract class TankBase : MonoBehaviour
    {
        protected TankData Data { get; set; }
        
        [Inject]
        public virtual void Initialize(TankData data)
        {
            Data = data;
            name = data.name + " " + Random.Range(0, 100);
        }
    }
}