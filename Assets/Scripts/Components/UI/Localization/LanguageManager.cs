using Events;
using Extensions.Unity.MonoHelper;
using Settings;
using TMPro;
using UnityEngine;
using Zenject;

namespace Components.UI.Localization
{
    public class LanguageManager : EventListenerMono
    {
        [Inject] private ProjectSettings ProjectSettings { get; set; }
        [Inject] private GameMenuEvents GameMenuEvents { get; set; }
        public TMP_Text[] translatedTexts;
        public string[] translationKeys;
        
        void Start()
        {
            ProjectSettings.Languages.SetLanguage((Languages)PlayerPrefs.GetInt(EnvVar.LanguagePrefKey, (int)Languages.Turkish));
            UpdateTexts();
        }
        
        protected override void RegisterEvents()
        {
            GameMenuEvents.LanguageSet += OnLanguageSet;
        }

        void UpdateTexts()
        {
            for (int i = 0; i < translatedTexts.Length; i++)
            {
                translatedTexts[i].text = ProjectSettings.Languages.GetTranslation(translationKeys[i]);
            }
        }

        private void OnLanguageSet(Languages arg0)
        {
            ProjectSettings.Languages.SetLanguage(arg0);
            UpdateTexts();
            PlayerPrefs.SetInt(EnvVar.LanguagePrefKey, (int)arg0);
            PlayerPrefs.Save();
        }

        protected override void UnRegisterEvents()
        {
            GameMenuEvents.LanguageSet -= OnLanguageSet;
        }
    }
}