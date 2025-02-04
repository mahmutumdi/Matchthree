using System;
using Components;
using Components.UI.Localization;
using Extensions.Unity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = nameof(ProjectSettings), menuName = EnvVar.ProjectSettingsPath, order = 0)]
    public class ProjectSettings : ScriptableObject
    {
        [SerializeField] private GridManager.Settings _gridManagerSettings;
        public GridManager.Settings GridManagerSettings => _gridManagerSettings;
        
        [FoldoutGroup(groupName:"Language Settings", expanded:false)]
        [SerializeField] private LanguageDict _languages;
        public LanguageDict Languages => _languages;
        
        [SerializeField] private AudioManager.Settings _audioManagerSettings;
        public AudioManager.Settings AudioManagerSettings => _audioManagerSettings;
    }

    [Serializable]
    public class LanguageDict : UnityDictionary<Languages, LanguageScriptableObject>
    {
        private LanguageScriptableObject currentLanguage;
        
        public void SetLanguage(Languages language)
        {
            switch (language)
            {
                case Languages.Turkish:
                    currentLanguage = this[Languages.Turkish];
                    break;
                case Languages.English:
                    currentLanguage = this[Languages.English];
                    break;
                default:
                    currentLanguage = this[Languages.Turkish];
                    break;
            }
            PlayerPrefs.SetInt(EnvVar.LanguagePrefKey, (int)language);
            PlayerPrefs.Save();
        }

        public string GetTranslation(string key)
        {
            if (currentLanguage == null)
            {
                Debug.LogWarning("Current language is not set.");
                return key;
            }
            return currentLanguage.GetTranslation(key);
        }
    }
}