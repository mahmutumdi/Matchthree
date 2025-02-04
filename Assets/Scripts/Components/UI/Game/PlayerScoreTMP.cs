using DG.Tweening;
using Events;
using Extensions.DoTween;
using Extensions.Unity.MonoHelper;
using UnityEngine;
using Zenject;

namespace Components.UI.Game
{
    public class PlayerScoreTMP : UITMP, ITweenContainerBind
    {
        [Inject] private GridEvents GridEvents{get;set;}
        private Tween _counterTween;
        private int _currCounterVal;
        private int _playerScore;
        
        public ITweenContainer TweenContainer{get;set;}

        private void Awake()
        {
            TweenContainer = TweenContain.Install(this);
        }

        protected override void RegisterEvents()
        {
            GridEvents.MatchGroupDespawn += OnMatchGroupDespawn;
        }

        private void OnMatchGroupDespawn(int matchNum)
        {
            _playerScore += matchNum;

            if(_counterTween.IsActive()) _counterTween.Kill();
            
            _counterTween = DOVirtual.Int
            (
                _currCounterVal,
                _playerScore,
                1f,
                OnCounterUpdate
            );

            TweenContainer.AddTween = _counterTween;
            
            SaveHighScore();
        }
        
        private void SaveHighScore()
        {
            int highScore = PlayerPrefs.GetInt(EnvVar.HighScorePrefKey, 0);
            if (_playerScore > highScore)
            {
                PlayerPrefs.SetInt(EnvVar.HighScorePrefKey, _playerScore);
                PlayerPrefs.Save();
            }
        }

        private void OnCounterUpdate(int val)
        {
            _currCounterVal = val;
            _myTMP.text = _currCounterVal.ToString();
        }

        protected override void UnRegisterEvents()
        {
            GridEvents.MatchGroupDespawn -= OnMatchGroupDespawn;
        }
    }
}