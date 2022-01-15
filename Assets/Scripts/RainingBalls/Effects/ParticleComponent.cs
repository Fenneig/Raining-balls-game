using UnityEngine;
using UnityEngine.Events;

namespace RainingBalls.Effects
{
    public class ParticleComponent : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particle;
        [SerializeField] private UnityEvent _event;

        private void Update()
        {
            if (!_particle.IsAlive()) _event?.Invoke();
        }
    }
}