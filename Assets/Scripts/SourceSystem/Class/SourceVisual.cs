using SourceSystem.Base;
using UnityEngine;

namespace SourceSystem.Class
{
    public class SourceVisual : SourceVisualBase
    {
        [SerializeField] private SpriteRenderer spriteRenderer = null;
        public override void SetVisual(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }
    }
}