using UnityEngine;

namespace NodeSystem
{
    public class CircleSprayerArea : SprayerAreaBase
    {
        public override Vector3 SprayPosition()
        {
            var randomPoint = Random.insideUnitCircle * radius;
                    
            return center.position + new Vector3(randomPoint.x, randomPoint.y, 0F);
        }
    }
}