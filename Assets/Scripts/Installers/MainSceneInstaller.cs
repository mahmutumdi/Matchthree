using System;
using DG.Tweening;
using Events;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Installers
{
    public class MainSceneInstaller : MonoInstaller<MainSceneInstaller>
    {
        [Inject] private GameMenuEvents _gameMenuEvents { get; set; }
        [SerializeField] private Camera _camera;
        [SerializeField] private GameObject _gameSettingsPanel;
        [SerializeField] private GameObject _pauseButton;

        public override void InstallBindings()
        {
            Container.BindInstance(_camera);
        }
        
        private void Awake()
        {
            _gameSettingsPanel.SetActive(false);
        }
        
        private void OnEnable()
        {
            _gameMenuEvents.PauseGameBtnUAction += OnPauseGameBTN;
            _gameMenuEvents.ContinueGameBtnUAction += OnContinueGameBTN;
            _gameMenuEvents.ReplayGameBtnUAction += OnReplayGameBTN;
            _gameMenuEvents.ExitGameBtnUAction += OnExitGameBTN;
            _gameMenuEvents.GameOver += OnGameOver;
        }
        
        private void OnGameOver()
        {
            _pauseButton.SetActive(false);
            _gameSettingsPanel.SetActive(false);
        }
        
        private void OnPauseGameBTN()
        {
            DOVirtual.DelayedCall(0.25f, () =>
            {
                _gameSettingsPanel.SetActive(true);
            });
            Time.timeScale = 0;
        }

        private void OnContinueGameBTN()
        {
            Time.timeScale = 1;
            DOVirtual.DelayedCall(0.25f, () =>
            {
                _gameSettingsPanel.SetActive(false);
            });
        }

        private void OnReplayGameBTN()
        {
            DOVirtual.DelayedCall(0.25f, () =>
            {
                _gameSettingsPanel.SetActive(false);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            });
        }
        
        private void OnExitGameBTN()
        {
            DOVirtual.DelayedCall(0.25f, () => SceneManager.LoadScene(EnvVar.MenuSceneName));
        }
        
        private void OnDisable()
        {
            _gameMenuEvents.PauseGameBtnUAction -= OnPauseGameBTN;
            _gameMenuEvents.ContinueGameBtnUAction -= OnContinueGameBTN;
            _gameMenuEvents.ReplayGameBtnUAction -= OnReplayGameBTN;
            _gameMenuEvents.ExitGameBtnUAction -= OnExitGameBTN;
            _gameMenuEvents.GameOver -= OnGameOver;
        }
    }
}