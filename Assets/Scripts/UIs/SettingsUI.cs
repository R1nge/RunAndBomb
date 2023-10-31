using System;
using Services;
using Services.Data.Settings;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UIs
{
    public class SettingsUI : MonoBehaviour
    {
        [SerializeField] private Button open, close;
        [SerializeField] private Canvas ui;
        [SerializeField] private Button sounds, vibration;
        private SettingsService _settingsService;
        private ISettingsDataService _settingsDataService;
        
        [Inject]
        private void Inject(SettingsService settingService, ISettingsDataService settingsDataService)
        {
            _settingsService = settingService;
            _settingsDataService = settingsDataService;
        }

        private void Awake()
        {
            ui.gameObject.SetActive(false);
            
            open.onClick.AddListener(Open);
            close.onClick.AddListener(Close);
            
            sounds.onClick.AddListener(SwitchSounds);
            vibration.onClick.AddListener(SwitchVibration);
        }

        private void Open()
        {
            sounds.image.color = _settingsDataService.Model.SoundEnabled ? Color.green : Color.red;
            vibration.image.color  = _settingsDataService.Model.VibrationEnabled ? Color.green : Color.red;
            ui.gameObject.SetActive(true);
        }

        private void Close()
        {
            ui.gameObject.SetActive(false);
            _settingsDataService.Save();
        }

        private void SwitchSounds()
        {
            _settingsService.SetSoundStatus(!_settingsDataService.Model.SoundEnabled);
            sounds.image.color = _settingsDataService.Model.SoundEnabled ? Color.green : Color.red;
        }

        private void SwitchVibration()
        {
            _settingsService.SetVibrationStatus(!_settingsDataService.Model.VibrationEnabled);
            vibration.image.color  = _settingsDataService.Model.VibrationEnabled ? Color.green : Color.red;
        }
    }
}