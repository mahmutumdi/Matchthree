using Extensions.Unity.MonoHelper;
using TMPro;
using UnityEngine;
using System.Collections;
using Events;
using Zenject;

namespace Components.UI.Game
{
    public class TimerSLIDER : UISlider
    {
        [Inject] private GameMenuEvents GameMenuEvents { get; set; }
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private GameObject _timerPanel;
        private const float _timeLimit = 30f;
        private float _currentTime;
        private bool _isRunning = false;
        private Coroutine _timerCoroutine;

        protected override void OnEnable()
        {
            ActivateTimerPanel();
            ResetTimer();
            StartTimer();

            GameMenuEvents.IncreaseTime += OnIncreaseTime;
        }

        private void OnIncreaseTime(float amount)
        {
            _currentTime = Mathf.Min(_currentTime + amount, _timeLimit);
            UpdateTimerUI();
        }
        
        private void ActivateTimerPanel()
        {
            _timerPanel.SetActive(true);
        }

        private void DeactivateTimerPanel()
        {
            _timerPanel.SetActive(false);
        }

        private void StartTimer()
        {
            if (!_isRunning)
            {
                _isRunning = true;
                if (_timerCoroutine == null)
                {
                    _timerCoroutine = StartCoroutine(TimerRoutine());
                }
            }
        }

        private void StopTimer()
        {
            _isRunning = false;
            if (_timerCoroutine != null)
            {
                StopCoroutine(_timerCoroutine);
                _timerCoroutine = null;
            }
        }

        private void ResetTimer()
        {
            _currentTime = _timeLimit;
            UpdateTimerUI();
            Time.timeScale = 1;
        }

        private void UpdateTimerUI()
        {
            _timerText.text = Mathf.Ceil(_currentTime).ToString();
            value = _currentTime / _timeLimit;
        }

        private void GameOver()
        {
            StopTimer();
            DeactivateTimerPanel();
            GameMenuEvents.GameOver?.Invoke();
        }

        private IEnumerator TimerRoutine()
        {
            while (_isRunning && _currentTime > 0)
            {
                yield return null;
                _currentTime -= Time.deltaTime;
                UpdateTimerUI();
            }

            if (_currentTime <= 0)
            {
                _currentTime = 0;
                UpdateTimerUI();
                GameOver();
            }
        }
        
        protected override void OnDisable()
        {
            StopTimer();
            DeactivateTimerPanel();
            
            GameMenuEvents.IncreaseTime -= OnIncreaseTime;
        }
    }
}