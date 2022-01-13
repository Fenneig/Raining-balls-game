using RainingBalls.Data;
using RainingBalls.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace RainingBalls
{
    public class BallHitComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _particle;
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Image _image;

        private delegate void OnHit(Color color);

        public void Hit()
        {
            PlayerData.Instance.Score++;
            var myTransform = new Vector3(_rectTransform.anchoredPosition.x, _rectTransform.anchoredPosition.y);
            SpawnUtil.Spawn(_particle, myTransform);
        }

        private Color GetImageColor()
        {
            var x = (int) _image.rectTransform.rect.width / 2;
            var y = (int) _image.rectTransform.rect.height / 2;
            var color = _image.sprite.texture.GetPixel(x, y);
            color.a = 1;
            return color;
        }
    }
}