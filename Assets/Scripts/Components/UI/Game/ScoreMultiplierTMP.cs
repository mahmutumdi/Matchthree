using DG.Tweening;
using Events;
using Extensions.DoTween;
using Extensions.Unity.MonoHelper;
using UnityEngine;
using Zenject;

namespace Components.UI.Game
{
    public class ScoreMultiplierTMP : UITMP, ITweenContainerBind
    {
        [Inject] private GridEvents GridEvents { get; set; }
        /*
            I didn't include "_scaleDuration" and "_resetDuration" variables in EnvVar because they are only used here, 
            and they can be written as float if desired. But for readability, I used const not float.
        */
        private const float _scaleDuration = 0.5f;
        private const float _resetDuration = 0.4f;
        private Tween _multiplierTween;
        private int _scoreMultiplier;
        
        public ITweenContainer TweenContainer { get; set; }

        private void Awake()
        {
            TweenContainer = TweenContain.Install(this);
        }

        protected override void RegisterEvents()
        {
            GridEvents.ScoreMultiChanged += OnScoreMultiplierChanged;
        }
        
        private void OnScoreMultiplierChanged(int multiplier)
        {
            _scoreMultiplier = multiplier;

            if (_scoreMultiplier > 0)
            {
                _multiplierTween?.Kill();

                _multiplierTween = transform.DOScale(
                    Vector3.one * 2f,
                    _scaleDuration
                ).OnComplete(() =>
                {
                    transform.DOScale(
                        Vector3.one,
                        _resetDuration
                    ).OnComplete(() =>
                    {
                        transform.rotation = Quaternion.identity;
                    });
                });
            }
            else
            {
                transform.DOScale(Vector3.one, _resetDuration);
                transform.rotation = Quaternion.identity;
            }

            _myTMP.text = $"x{_scoreMultiplier}";
        }
        
        protected override void UnRegisterEvents()
        {
            GridEvents.ScoreMultiChanged -= OnScoreMultiplierChanged;
        }
    }
}