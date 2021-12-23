using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace RainingBalls.ObjectPool
{
    public class Pool : MonoBehaviour
    {

        private readonly Dictionary<int, Queue<PoolItem>> _items = new Dictionary<int, Queue<PoolItem>>();
        private static Pool _instance;
        private static Canvas _canvas;
        private static GameObject _pool;

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
            InitComponent();

            var id = go.GetInstanceID();
            var queue = RequireQueue(id);

            if (queue.Count > 0)
            {
                var pooledItem = queue.Dequeue();
                pooledItem.transform.localPosition = position;
                pooledItem.gameObject.SetActive(true);

                return pooledItem.gameObject;
            }

            var instance = Instantiate(go, _pool.transform);
            var poolItem = instance.GetComponent<PoolItem>();
            instance.transform.localPosition = position;
            poolItem.Retain(id, this);


            return instance;
        }

        private void InitComponent()
        {
            if (_canvas == null)
                _canvas = FindObjectsOfType<Canvas>().FirstOrDefault(canvas => canvas.CompareTag("PlayCanvas"));

            if (_pool == null)
            {
                _pool = Instantiate(gameObject, _canvas.transform);
                _pool.name = "###OBJECT_POOL###";
            }
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