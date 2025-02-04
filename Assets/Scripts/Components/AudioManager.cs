using System;
using System.Collections.Generic;
using Events;
using Extensions.Unity.MonoHelper;
using Settings;
using UnityEngine;
using Zenject;

namespace Components
{
    public class AudioManager : EventListenerMono
    {
        [Inject] private AudioEvents _audioEvents { get; set; }
        [Inject] private GridEvents GridEvents { get; set; }
        [Inject] private ProjectSettings _projectSettings { get; set; }
        
        [SerializeField] private AudioSource _musicAudioSource;
        [SerializeField] private AudioSource _soundAudioSource;
        [SerializeField] private bool _isVibrationEnabled;
        
        private AudioManager.Settings _mySettings;

        void Awake()
        {
            _mySettings = _projectSettings.AudioManagerSettings;
        }
        
        protected override void OnEnable()
        {
            base.OnEnable();
            
            _musicAudioSource.volume = PlayerPrefs.GetFloat(EnvVar.MusicPrefKey, 1f);
            SetAudioClip(EnvVar.Music1Name);
            
            _soundAudioSource.volume = PlayerPrefs.GetFloat(EnvVar.SoundPrefKey, 1f);
            
            _isVibrationEnabled = PlayerPrefs.GetInt(EnvVar.VibrationPrefKey, 1) == 1;
        }
        
        protected override void RegisterEvents()
        {
            _audioEvents.MusicSliderUAction += MusicSliderValueChanged;
            _audioEvents.SoundSliderUAction += SoundSliderValueChanged;
            _audioEvents.VibrationToggleUAction += VibrationToggleValueChanged;
            
            GridEvents.NormalTileDespawned += OnNormalTileDespawned;
            GridEvents.PowerupTileDespawned += OnPowerupTileDespawned;
        }

        private void SetAudioClip(string clipName)
        {
            //I used list of audioClips to show I can use multiple musics if I want.
            AudioClip clip = _mySettings.AudioClips.Find(c => c.name == clipName);
            if (clip != null)
            {
                _musicAudioSource.clip = clip;
                _musicAudioSource.Play();
            }
            else
            {
                Debug.LogWarning($"Audio clip with name {clipName} not found in ProjectSettings.");
            }
        }
        
        private void OnNormalTileDespawned()
        {
            if (PlayerPrefs.GetInt(EnvVar.SoundPrefKey, 1) == 1)
            {
                _soundAudioSource.PlayOneShot(_mySettings.NormalTileDestroySound);
            }
        }
        private void OnPowerupTileDespawned()
        {
            if (PlayerPrefs.GetInt(EnvVar.SoundPrefKey, 1) == 1)
            {
                _soundAudioSource.PlayOneShot(_mySettings.PowerupTileDestroySound);
            }
        }

        private void MusicSliderValueChanged(float val)
        {
            PlayerPrefs.SetFloat(EnvVar.MusicPrefKey, val);
            _musicAudioSource.volume = val;
        }
        
        private void SoundSliderValueChanged(float val)
        {
            PlayerPrefs.SetFloat(EnvVar.SoundPrefKey, val);
            _soundAudioSource.volume = val;
        }
        
        private void VibrationToggleValueChanged(bool isOn)
        {
            _isVibrationEnabled = isOn;
            PlayerPrefs.SetInt(EnvVar.VibrationPrefKey, _isVibrationEnabled ? 1 : 0);
            PlayerPrefs.Save();
        }

        protected override void UnRegisterEvents()
        {
            _audioEvents.MusicSliderUAction -= MusicSliderValueChanged;
            _audioEvents.SoundSliderUAction -= SoundSliderValueChanged;
            _audioEvents.VibrationToggleUAction -= VibrationToggleValueChanged;
            
            GridEvents.NormalTileDespawned -= OnNormalTileDespawned;
            GridEvents.PowerupTileDespawned -= OnPowerupTileDespawned;
        }

        [Serializable]
        public class Settings
        {
            [SerializeField] private List<AudioClip> _audioClips;
            public List<AudioClip> AudioClips => _audioClips;
            
            
            [SerializeField] private AudioClip _normalTileDestroySound;
            public AudioClip NormalTileDestroySound => _normalTileDestroySound;
            
            
            [SerializeField] private AudioClip _powerupTileDestroySound;
            public AudioClip PowerupTileDestroySound => _powerupTileDestroySound;
            
        }
    }
}