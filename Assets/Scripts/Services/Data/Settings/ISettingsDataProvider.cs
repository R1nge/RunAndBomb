namespace Services.Data.Settings
{
    public interface ISettingsDataProvider
    {
        public Services.Settings Load();
        public void Save(Services.Settings data);
    }
}