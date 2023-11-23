using System.Threading.Tasks;
using Services.Data.Settings;
using UnityEngine.Localization.Settings;

namespace Services
{
    public class LocalizationService
    {
        private readonly ISettingsDataService _settingsDataService;

        private LocalizationService(ISettingsDataService settingsDataService) => _settingsDataService = settingsDataService;

        public async Task SetLocalization(Languages language)
        {
            await LocalizationSettings.InitializationOperation.Task;
            _settingsDataService.Model.Language = language;
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[(int)language];
        }

        public enum Languages
        {
            EN = 0,
            RU = 1,
            UA = 2
        }
    }
}