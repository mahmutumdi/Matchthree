using UnityEngine;
using UnityEngine.UI;

namespace Extensions.Unity.MonoHelper
{
    public abstract class UIToggle : EventListenerMono
    {
        [SerializeField] private Toggle _vibrationToggle;
        protected override void RegisterEvents()
        {
            _vibrationToggle.onValueChanged.AddListener(OnValueChanged);
        }
        
        protected abstract void OnValueChanged(bool isOn);

        protected override void UnRegisterEvents()
        {
            _vibrationToggle.onValueChanged.AddListener(OnValueChanged);
        }
    }
}