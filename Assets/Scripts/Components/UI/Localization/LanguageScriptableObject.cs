using System;
using Extensions.Unity;
using UnityEngine;

namespace Components.UI.Localization
{
    [CreateAssetMenu(fileName = "Language Data", menuName = EnvVar.LanaguageSOPath, order = 1)]
    public class LanguageScriptableObject : ScriptableObject
    {
        [SerializeField] private LangMapDict _langMapDict;
        public LangMapDict LangMapDict => _langMapDict;
        
        public string languageName;
        public string[] keys;
        public string[] values;

        public string GetTranslation(string key)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i] == key)
                {
                    return values[i];
                }
            }
            return null;
        }
    }
    [Serializable]
    public class LangMapDict : UnityDictionary<string, string>{} 
}