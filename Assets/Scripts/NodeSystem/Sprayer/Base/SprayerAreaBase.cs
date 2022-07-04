using UnityEngine;

namespace NodeSystem.Sprayer.Base
{
    [ExecuteInEditMode]
    public abstract class SprayerAreaBase : MonoBehaviour
    {
        [SerializeField] protected Transform center = null;

        [Range(0F, 10F)]
        [SerializeField] protected float radius = 1.5F;
        
        public abstract Vector3 SprayPosition();

        private void OnValidate()
        {
            if(center == null) return;
            
            center.localScale = (radius * 1.3333F) * Vector3.one;
        }
    }
}