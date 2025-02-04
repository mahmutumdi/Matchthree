using Events;
using Zenject;

namespace Components.UI.Localization
{
    public class SetTurkishLanguageBTN : UIBTN
    {
        [Inject] private GameMenuEvents GameMenuEvents{ get; set; }
        
        protected override void OnClick()
        {
            GameMenuEvents.LanguageSet?.Invoke(Languages.Turkish);
        }
    }
}