using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Factorio.Simulation.Managers
{
    public class SimulationUIElement : MonoBehaviour
    {
        private Image _image = null;
        private TextMeshProUGUI _content = null;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _content = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void Animate(float duration, bool isReverse, float delay, bool raycastTarget = true)
        {
            var alpha = 0F;
            var imageCurrentColor = _image.color;
            var imageTargetColor = imageCurrentColor;
            imageTargetColor.a = isReverse ? .75F : 0F;
            
            var textCurrentColor = _content.color;
            var textTargetColor = textCurrentColor;
            textTargetColor.a = isReverse ? 1F : 0F;

            _image.raycastTarget = raycastTarget;
            
            DOVirtual.DelayedCall(delay, () =>
            {
                DOTween.To(() => alpha, x => alpha = x, 1F, duration / 2F).OnUpdate(() =>
                {
                    _image.color = Color.Lerp(imageCurrentColor, imageTargetColor, alpha);
                    _content.color = Color.Lerp(textCurrentColor, textTargetColor, alpha);
                });
            });
        }
    }
}