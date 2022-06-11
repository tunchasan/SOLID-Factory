using UnityEngine;

namespace AreaSystem.Base
{
    public abstract class AreaBase : MonoBehaviour
    {
        protected abstract void OnTriggerEnter2D(Collider2D col);
    }
}