using UnityEngine;
using UnityEngine.Events;

namespace RainingBalls
{
    public class ParticleComponent : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particle;
        [SerializeField] private UnityEvent _event;

        public void ChangeColor(Color color)
        {
            var main = _particle.main;
            main.startColor = new ParticleSystem.MinMaxGradient(color);
        }

        private void Update()
        {
            if (!_particle.IsAlive()) _event?.Invoke();
        }
    }
}