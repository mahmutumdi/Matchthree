using System;
using Components.UI.Menu;
using DG.Tweening;
using Events;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Installers
{
    public class MenuSceneInstaller : MonoInstaller<MainSceneInstaller>
    {
        [Inject] private MenuEvents _menuEvents { get; set; }
        [SerializeField] private Camera _camera;
        [SerializeField] private GameObject _settingsAboutPanel;
        [SerializeField] private Toggle _vibrationToggle;
        [SerializeField] private Slider _soundSlider;
        [SerializeField] private Slider _musicSlider;
        [SerializeField] private TMP_Text _highScoreTMP;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_camera);
        }
        
        private void Awake()
        {
            _settingsAboutPanel.SetActive(false);
        }

        private void OnEnable()
        {
            _menuEvents.StartGameBtnUAction += OnStartGameBTN;
            _menuEvents.SettingsAboutBtnUAction += OnSettingsAboutBTN;
            _menuEvents.ExitSettingsAboutBtnUAction += OnExitSettingsAboutBTN;
            _menuEvents.SocialInstagramBtnUAction += OnSocialInstagramBTN;
            _menuEvents.SocialWebBtnUAction += OnSocialWebBTN;
            _menuEvents.SocialXBtnUAction += OnSocialXBTN;
            _menuEvents.SocialYoutubeBtnUAction += OnSocialYoutubeBTN;
        }

        void Start()
        {
            bool isVibrationOn = PlayerPrefs.GetInt(EnvVar.VibrationPrefKey, 1) == 1;
            _vibrationToggle.isOn = isVibrationOn;

            float musicVolume = PlayerPrefs.GetFloat(EnvVar.MusicPrefKey, 1.0f);
            _musicSlider.value = musicVolume;
            
            float soundVolume = PlayerPrefs.GetFloat(EnvVar.SoundPrefKey, 1.0f);
            _soundSlider.value = soundVolume;
            
            int highScore = PlayerPrefs.GetInt(EnvVar.HighScorePrefKey, 0);
            _highScoreTMP.text = highScore.ToString();
        }

        void OnSocialInstagramBTN()
        {
            Application.OpenURL("https://www.google.com");
            //I put empty google link, to showcase.
        }
        void OnSocialWebBTN()
        {
            Application.OpenURL("https://www.google.com");
            //I put empty google link, to showcase.
        }
        void OnSocialXBTN()
        {
            Application.OpenURL("https://www.google.com");
            //I put empty google link, to showcase.
        }
        void OnSocialYoutubeBTN()
        {
            Application.OpenURL("https://www.google.com");
            //I put empty google link, to showcase.
        }

        void OnStartGameBTN()
        {
            DOVirtual.DelayedCall(0.5f, () => SceneManager.LoadScene(EnvVar.MainSceneName));
        }

        void OnSettingsAboutBTN()
        {
            DOVirtual.DelayedCall(0.5f, () => _settingsAboutPanel.SetActive(true));
        }

        private void OnExitSettingsAboutBTN()
        {
            _settingsAboutPanel.SetActive(false);
            
        }
        
        private void OnDisable()
        {
            _menuEvents.StartGameBtnUAction -= OnStartGameBTN;
            _menuEvents.SettingsAboutBtnUAction -= OnSettingsAboutBTN;
            _menuEvents.ExitSettingsAboutBtnUAction -= OnExitSettingsAboutBTN;
            _menuEvents.SocialInstagramBtnUAction -= OnSocialInstagramBTN;
            _menuEvents.SocialWebBtnUAction -= OnSocialWebBTN;
            _menuEvents.SocialXBtnUAction -= OnSocialXBTN;
            _menuEvents.SocialYoutubeBtnUAction -= OnSocialYoutubeBTN;
        }
    }
}