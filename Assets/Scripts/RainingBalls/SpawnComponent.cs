using System.Collections;
using RainingBalls.ObjectPool;
using UnityEngine;
using UnityEngine.UI;

namespace RainingBalls
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D _area;
        [SerializeField] private GameObject _prefabToSpawn;
        [SerializeField] private float _timeBetweenSpawns;
        [SerializeField] private BallChooser _chooser;

        private float _halfAreaSize;

        private bool _isPlaying;

        public void StartGame()
        {
            _halfAreaSize = _area.transform.localScale.x / 2f;
            _isPlaying = true;
            StartCoroutine(Play());
        }

        public void StopGame()
        {
            _isPlaying = false;
        }

        private IEnumerator Play()
        {
            while (_isPlaying)
            {
                Spawn();
                yield return new WaitForSeconds(_timeBetweenSpawns);
            }
        }

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            var randomXPosition = Random.Range(-_halfAreaSize, _halfAreaSize);
            var areaTransform = _area.transform.localPosition;
            var newPosition = new Vector3(randomXPosition, areaTransform.y);

            var ball = Pool.Instance.Get(_prefabToSpawn, newPosition);
            ball.GetComponentInChildren<Image>().sprite = _chooser.GetRandomBall();
        }
    }
}