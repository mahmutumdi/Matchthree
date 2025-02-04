using Events;
using Extensions.Unity.MonoHelper;
using Zenject;

namespace Components.UI.Menu
{
    public class VibrationTOGGLE : UIToggle
    {
        [Inject]
        private AudioEvents _audioEvents{ get; set; }
        protected override void OnValueChanged(bool isOn)
        {
            _audioEvents.VibrationToggleUAction?.Invoke(isOn);
        }
    }
}