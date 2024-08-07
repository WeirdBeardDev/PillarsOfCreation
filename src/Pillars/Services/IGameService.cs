﻿namespace Wbd.Pillars.Services;

public interface IGameService
{
    #region Properties
    string Version { get; }
    DataDbService DataDb { get; }
    PlayerService Player { get; }
    SaveService Storage { get; }
    TimerService Timer { get; }
    #endregion Properties

    #region Methods
    Task StartGameAsync();
    #endregion Methods
}
