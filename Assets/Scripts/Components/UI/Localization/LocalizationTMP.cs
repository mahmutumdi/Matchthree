using Events;
using Extensions.Unity.MonoHelper;
using Settings;
using Zenject;

namespace Components.UI.Localization
{
    public class LocalizationTMP : UITMP
    {
        [Inject] private ProjectSettings ProjectSettings { get; set; }
        [Inject] private GameMenuEvents GameMenuEvents { get; set; }
    
        protected override void RegisterEvents()
        {
            GameMenuEvents.LanguageSet += OnLanguageSet;
        }

        private void OnLanguageSet(Languages languages)
        {
            _myTMP.text = ProjectSettings.Languages[languages].LangMapDict[gameObject.name];
        }

        protected override void UnRegisterEvents()
        {
            GameMenuEvents.LanguageSet -= OnLanguageSet;
        }
    }
}
