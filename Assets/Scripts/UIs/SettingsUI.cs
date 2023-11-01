using Services;
using Services.Data.Settings;
using TMPro;
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
        [SerializeField] private TextMeshProUGUI soundText, vibrationText;
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
            soundText.text = _settingsDataService.Model.SoundEnabled ? "ENABLED" : "DISABLED";
            vibrationText.text = _settingsDataService.Model.VibrationEnabled ? "ENABLED" : "DISABLED";
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
            soundText.text = _settingsDataService.Model.SoundEnabled ? "ENABLED" : "DISABLED";
        }

        private void SwitchVibration()
        {
            _settingsService.SetVibrationStatus(!_settingsDataService.Model.VibrationEnabled);
            vibrationText.text = _settingsDataService.Model.VibrationEnabled ? "ENABLED" : "DISABLED";
        }
    }
}