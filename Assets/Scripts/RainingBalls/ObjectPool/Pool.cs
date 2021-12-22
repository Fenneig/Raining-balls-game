using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace RainingBalls.ObjectPool
{
    public class Pool : MonoBehaviour
    {
        private readonly Dictionary<int, Queue<PoolItem>> _items = new Dictionary<int, Queue<PoolItem>>();
        private static Pool _instance;

        public static Pool Instance
        {
            get
            {
                if (_instance == null)
                {
                    var go = new GameObject("ObjectPool");
                    _instance = go.AddComponent<Pool>();
                }

                return _instance;
            }
        }

        public GameObject Get(GameObject go, Vector3 position)
        {
            var id = go.GetInstanceID();
            var queue = RequireQueue(id);

            if (queue.Count > 0)
            {
                var pooledItem = queue.Dequeue();
                pooledItem.transform.position = position;
                pooledItem.gameObject.SetActive(true);
                return pooledItem.gameObject;
            }

            var instance = Instantiate(go, position, quaternion.identity, gameObject.transform);
            var poolItem = instance.GetComponent<PoolItem>();
            poolItem.Retain(id, this);

            return instance;
        }

        private Queue<PoolItem> RequireQueue(int id)
        {
            if (_items.TryGetValue(id, out var queue)) return queue;


            queue = new Queue<PoolItem>();
            _items.Add(id, queue);
            return queue;
        }

        public void Release(int id, PoolItem poolItem)
        {
            var queue = RequireQueue(id);
            queue.Enqueue(poolItem);

            poolItem.gameObject.SetActive(false);
        }
    }
}