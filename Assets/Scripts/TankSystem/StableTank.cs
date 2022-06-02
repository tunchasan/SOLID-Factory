using UnityEngine;
using Zenject;

namespace TankSystem
{
    public class StableTank : Tank
    {
        protected override TankData Data { get; set; }
        
        [Inject]
        public override void Initialize(TankData data)
        {
            Data = data;
            name = Data.name + " " + Random.Range(0, 100);
        }
    }
}