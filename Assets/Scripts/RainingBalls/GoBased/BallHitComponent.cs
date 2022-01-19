using RainingBalls.Data;
using RainingBalls.Effects;
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
            var particle = SpawnUtil.Spawn(_particle, myTransform);
            Recolorer.RecolorParticle(particle.GetComponent<ParticleSystem>(), _image);
        }
    }
}