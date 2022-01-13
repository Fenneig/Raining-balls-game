using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RainingBalls.ObjectPool
{
    public class Pool : MonoBehaviour
    {
        private readonly Dictionary<int, Queue<PoolItem>> _items = new Dictionary<int, Queue<PoolItem>>();
        private static Pool _instance;
        private static Canvas _canvas;
        private static bool _isInitialized;
        private const string ContainerName = "###OBJECT_POOL###";

        public static Pool Instance
        {
            get
            {
                if (_instance == null) _instance = new GameObject().AddComponent<Pool>();

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

            var instance = Instantiate(go, _instance.transform);
            var poolItem = instance.GetComponent<PoolItem>();
            instance.transform.localPosition = position;
            poolItem.Retain(id, this);


            return instance.gameObject;
        }

        private void InitComponent()
        {
            if (_isInitialized) return;

            _canvas = FindObjectsOfType<Canvas>().FirstOrDefault(canvas => canvas.CompareTag("PlayCanvas"));
            _instance.transform.parent = _canvas.transform;
            _instance.name = ContainerName;
            _instance.transform.localScale = Vector3.one;
            _instance.transform.position = Vector3.zero;

            _isInitialized = true;
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