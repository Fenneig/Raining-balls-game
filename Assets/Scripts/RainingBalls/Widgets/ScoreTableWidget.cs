using RainingBalls.Data;
using UnityEngine;
using UnityEngine.UI;

namespace RainingBalls
{
    public class ScoreTableWidget : MonoBehaviour
    {
        [SerializeField] private Text _score;

        private void Start()
        {
            PlayerData.Instance.OnChange += OnChange;
        }

        private void OnChange()
        {
            _score.text = $"Score: {PlayerData.Instance.Score}";
        }
    }
}