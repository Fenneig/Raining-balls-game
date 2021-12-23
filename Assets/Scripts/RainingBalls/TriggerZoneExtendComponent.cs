using UnityEngine;

namespace RainingBalls
{
    public class TriggerZoneExtendComponent : MonoBehaviour
    {
        [SerializeField] private RectTransform _playCanvas;
        [SerializeField] private bool _isTopZone;

        private void Start()
        {
            transform.localScale = new Vector3(_playCanvas.rect.width, transform.localScale.y, 0);

            var newY = _isTopZone
                ? (_playCanvas.rect.height + transform.localScale.y) / 2
                : -(_playCanvas.rect.height + transform.localScale.y) / 2;

            transform.localPosition = new Vector3(0, newY);
        }
    }
}