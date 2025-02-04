using UnityEngine;

namespace Components.UI.Game
{
    public class ParticleAutoDestroy : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;

        void Update()
        {
            if (_particleSystem)
            {
                if (!_particleSystem.IsAlive())
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}