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

        [Inject]
        private void Inject(SettingsService settingService, ISettingsDataService settingsDataService)
        {
            _settingsService = settingService;
            _settingsDataService = settingsDataService;
        }

        private async void Awake()
        {
            ui.gameObject.SetActive(false);
            
            await LocalizationSettings.InitializationOperation.Task;

            open.onClick.AddListener(Open);
            close.onClick.AddListener(Close);

            sounds.onClick.AddListener(SwitchSounds);
            vibration.onClick.AddListener(SwitchVibration);

            english.onClick.AddListener(() => SetLanguage(0));
            russian.onClick.AddListener(() => SetLanguage(1));
            ukrainian.onClick.AddListener(() => SetLanguage(2));
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

        private async void SetLanguage(int index)
        {
            //en 0, ru 1, ua 2
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
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