using UnityEngine;
using System.Collections.Generic;
using Zenject;
using Events;

namespace Extensions.Unity.MonoHelper
{
    public abstract class UIBasicParticleSystem : EventListenerMono
    {
        [Inject] protected GridEvents GridEvents { get; set; }

        [SerializeField] protected ParticleSystem _particleSystem;

        protected override void RegisterEvents()
        {
            GridEvents.ScoreMultiChanged += OnScoreMultiChanged;
        }

        protected override void UnRegisterEvents()
        {
            GridEvents.ScoreMultiChanged -= OnScoreMultiChanged;
        }

        protected abstract void OnScoreMultiChanged(int scoreMuti);
    }
}