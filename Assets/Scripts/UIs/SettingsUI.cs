using System.Threading.Tasks;
using Services;
using Services.Data.Settings;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
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
        [SerializeField] private Button english, russian, ukrainian;
        [SerializeField] private LocalizedString enabled, disabled;
        private SettingsService _settingsService;
        private ISettingsDataService _settingsDataService;
        private LocalizationService _localizationService;

        [Inject]
        private void Inject(SettingsService settingService, ISettingsDataService settingsDataService, LocalizationService localizationService)
        {
            _settingsService = settingService;
            _settingsDataService = settingsDataService;
            _localizationService = localizationService;
        }

        private async void Awake()
        {
            ui.gameObject.SetActive(false);
            
            await LocalizationSettings.InitializationOperation.Task;

            open.onClick.AddListener(Open);
            close.onClick.AddListener(Close);

            sounds.onClick.AddListener(SwitchSounds);
            vibration.onClick.AddListener(SwitchVibration);

            english.onClick.AddListener(() => SetLanguage(LocalizationService.Languages.EN));
            russian.onClick.AddListener(() => SetLanguage(LocalizationService.Languages.RU));
            ukrainian.onClick.AddListener(() => SetLanguage(LocalizationService.Languages.UA));
        }

        private async void Open()
        {
            await LoadLocalization();
            ui.gameObject.SetActive(true);
        }

        private void Close()
        {
            ui.gameObject.SetActive(false);
            _settingsDataService.Save();
        }

        private async void SwitchSounds()
        {
            _settingsService.SetSoundStatus(!_settingsDataService.Model.SoundEnabled);
            await LoadLocalization();
        }

        private async void SwitchVibration()
        {
            _settingsService.SetVibrationStatus(!_settingsDataService.Model.VibrationEnabled);
            await LoadLocalization();
        }

        private async void SetLanguage(LocalizationService.Languages language)
        {
            await _localizationService.SetLocalization(language);
            await LoadLocalization();
        }

        private async Task LoadLocalization()
        {
            string enabledString = await enabled.GetLocalizedStringAsync().Task;
            string disabledString = await disabled.GetLocalizedStringAsync().Task;

            vibrationText.text = _settingsDataService.Model.SoundEnabled ? enabledString : disabledString;
            soundText.text = _settingsDataService.Model.SoundEnabled ? enabledString : disabledString;
        }
    }
}