using RainingBalls.ObjectPool;
using UnityEngine;

namespace RainingBalls.Spawners
{
    public class DespawnObjectComponent : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            other.GetComponent<PoolItem>().Release();
        }
    }
}