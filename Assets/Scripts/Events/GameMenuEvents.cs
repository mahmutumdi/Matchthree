using Components.UI.Localization;
using UnityEngine.Events;

namespace Events
{
    public class GameMenuEvents
    {
        public UnityAction PauseGameBtnUAction;
        public UnityAction ContinueGameBtnUAction;
        public UnityAction ReplayGameBtnUAction;
        public UnityAction ExitGameBtnUAction;
        public UnityAction<Languages> LanguageSet;
        public UnityAction GameOver;
        public UnityAction<float> IncreaseTime;
    }
}