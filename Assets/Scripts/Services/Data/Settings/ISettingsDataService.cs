﻿namespace Services.Data.Settings
{
    //TODO: can rid of it???
    public interface ISettingsDataService
    {
        void Save();
        void Load();
        Services.Settings Model { get; }
    }
}