using System.Collections;
using RainingBalls.ObjectPool;
using UnityEngine;

namespace RainingBalls
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D _area;
        [SerializeField] private GameObject _prefabToSpawn;
        [SerializeField] private float _timeBetweenSpawns;

        private float _halfAreaSize;

        private bool _isPlaying;

        private void Start()
        {
            _halfAreaSize = _area.size.x / 2f;
        }

        public void StartGame()
        {
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
            var areaTransform = _area.transform.position;
            var newPosition = new Vector3(areaTransform.x + randomXPosition, areaTransform.y);

            Pool.Instance.Get(_prefabToSpawn, newPosition);
        }
    }
}