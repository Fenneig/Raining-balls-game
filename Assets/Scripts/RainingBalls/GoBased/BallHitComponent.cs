using RainingBalls.Data;
using RainingBalls.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace RainingBalls.GoBased
{
    public class BallHitComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _particle;
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Image _image;

        public void Hit()
        {
            PlayerData.Instance.Score++;
            var myTransform = new Vector3(_rectTransform.anchoredPosition.x, _rectTransform.anchoredPosition.y);
            SpawnUtil.Spawn(_particle, myTransform);
        }
    }
}