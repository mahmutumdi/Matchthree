using Events;
using Zenject;

namespace Components.UI.Localization
{
    public class SetEnglishLanguageBTN : UIBTN
    {
        [Inject] private GameMenuEvents GameMenuEvents{ get; set; }
        
        protected override void OnClick()
        {
            GameMenuEvents.LanguageSet?.Invoke(Languages.English);
        }
    }
}