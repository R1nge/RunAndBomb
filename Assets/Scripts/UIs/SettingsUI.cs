using System.Collections;
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

        private void Awake()
        {
            ui.gameObject.SetActive(false);

            open.onClick.AddListener(Open);
            close.onClick.AddListener(Close);

            sounds.onClick.AddListener(SwitchSounds);
            vibration.onClick.AddListener(SwitchVibration);

            english.onClick.AddListener(() => StartCoroutine(SetLanguage(0)));
            russian.onClick.AddListener(() => StartCoroutine(SetLanguage(1)));
            ukrainian.onClick.AddListener(() => StartCoroutine(SetLanguage(2)));
        }

        private void Open()
        {
            soundText.text = _settingsDataService.Model.SoundEnabled ? enabled.GetLocalizedString() : disabled.GetLocalizedString();
            vibrationText.text = _settingsDataService.Model.VibrationEnabled ? enabled.GetLocalizedString() : disabled.GetLocalizedString();
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
            soundText.text = _settingsDataService.Model.SoundEnabled ? enabled.GetLocalizedString() : disabled.GetLocalizedString();
        }

        private void SwitchVibration()
        {
            _settingsService.SetVibrationStatus(!_settingsDataService.Model.VibrationEnabled);
            vibrationText.text = _settingsDataService.Model.VibrationEnabled ? enabled.GetLocalizedString() : disabled.GetLocalizedString();
        }

        private IEnumerator SetLanguage(int index)
        {
            yield return LocalizationSettings.InitializationOperation;
            //en 0, ru 1, ua 2
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
            vibrationText.text = _settingsDataService.Model.VibrationEnabled ? enabled.GetLocalizedString() : disabled.GetLocalizedString();
            soundText.text = _settingsDataService.Model.SoundEnabled ? enabled.GetLocalizedString() : disabled.GetLocalizedString();
        }
    }
}