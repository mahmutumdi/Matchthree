using Events;
using Zenject;

namespace Components.UI.Menu
{
    public class SocialWebBTN : UIBTN
    {
        [Inject]
        private MenuEvents _menuEvents{ get; set; }
        protected override void OnClick()
        {
            _menuEvents.SocialWebBtnUAction?.Invoke();
        }
    }
}