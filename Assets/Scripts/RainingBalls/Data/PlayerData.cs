using System;
using UnityEngine;

namespace RainingBalls.Data
{
    [Serializable]
    public class PlayerData : MonoBehaviour
    {
        [SerializeField] private int _score;

        public static PlayerData Instance;

        public event Action OnChange;

        public int Score
        {
            get => _score;

            set
            {
                _score = value;
                OnChange?.Invoke();
            }
        }

        private void Awake()
        {
            if (!Instance)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}