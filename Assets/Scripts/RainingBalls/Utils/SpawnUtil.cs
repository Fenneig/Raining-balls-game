using RainingBalls.ObjectPool;
using UnityEngine;

namespace RainingBalls.Utils
{
    public class SpawnUtil : MonoBehaviour
    {
        public static GameObject Spawn(GameObject go, Vector3 position)
        {
            return Pool.Instance.Get(go, position);
        }
    }
}