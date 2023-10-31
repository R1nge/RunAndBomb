﻿using Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UIs
{
    public class SettingsUI : MonoBehaviour
    {
        [SerializeField] private Button sounds, vibration;
        private SettingsService _settingsService;
        
        [Inject]
        private void Inject(SettingsService settingService) => _settingsService = settingService;

        private void Awake()
        {
            sounds.onClick.AddListener(SwitchSounds);
            vibration.onClick.AddListener(SwitchVibration);
            
            sounds.image.color = _settingsService.Settingss.SoundEnabled ? Color.green : Color.red;
            vibration.image.color  = _settingsService.Settingss.VibrationEnabled ? Color.green : Color.red;
        }

        private void SwitchSounds()
        {
            _settingsService.SetSoundStatus(!_settingsService.Settingss.SoundEnabled);
            sounds.image.color = _settingsService.Settingss.SoundEnabled ? Color.green : Color.red;
            print($"Sounds Enabled: {_settingsService.Settingss.SoundEnabled}");
        }

        private void SwitchVibration()
        {
            _settingsService.SetVibrationStatus(!_settingsService.Settingss.VibrationEnabled);
            vibration.image.color  = _settingsService.Settingss.VibrationEnabled ? Color.green : Color.red;
            print($"Vibration Enabled: {_settingsService.Settingss.SoundEnabled}");
        }
    }
}