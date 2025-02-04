using UnityEngine;
using UnityEngine.UI;

namespace Extensions.Unity.MonoHelper
{
    public abstract class UIBasicSlider : EventListenerMono
    {
        [SerializeField] protected Slider _slider;
        protected override void RegisterEvents()
        {
            _slider.onValueChanged.AddListener(OnValueChanged);
        }
        
        protected abstract void OnValueChanged(float val);

        protected override void UnRegisterEvents()
        {
            _slider.onValueChanged.AddListener(OnValueChanged);
        }
    }
}