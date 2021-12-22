using UnityEngine;

namespace RainingBalls
{
    public class BallMoverComponent : MonoBehaviour
    {
        [SerializeField] private Transform _deSpawnerDestination;
        [SerializeField] private float _speed;

        private void Update()
        {
            var Ypos = transform.position.y;
            if (Ypos >= _deSpawnerDestination.position.y)
                Ypos -= _speed;
            transform.position = new Vector3(transform.position.x, Ypos, transform.position.z);
        }
    }
}