﻿using System.Reflection;
using Blazored.LocalStorage;
using Wbd.Pillars.ClassLib.DataStore;

namespace Wbd.Pillars.Services;

public class GameService(ILocalStorageService storageService, ILogger<GameService> logger) : IGameService
{
    #region Events
    public event EventHandler OnLoad = default!;
    public event EventHandler OnSave = default!;
    #endregion Events

    #region Properties
    public Creator Creator { get; private set; } = new();
    public string Version => $"v{Assembly.GetExecutingAssembly().GetName().Version?.ToString(3)}" ?? "unknown";
    private ILocalStorageService Storage { get; set; } = storageService;
    private ILogger Logger { get; set; } = logger;
    #endregion Properties

    #region Ctor
    #endregion Ctor

    #region Methods
    public async Task LoadAsync() => await LoadCreatorAsync();
    public async Task SaveAsync() => await SaveCreatorAsync();
    public async Task<bool> DoesSaveExistAsync() => await Storage.ContainKeyAsync(Data.PlayerName);
    public async Task CreateSaveSlotAsync()
    {
        Creator = new();
        Logger.LogInformation($"New empty character created with {Creator.Characters.Count} slots.");
        await SaveCreatorAsync();
    }
    #endregion Methods

    #region Helpers
    private async Task LoadCreatorAsync()
    {
        var c = await Storage.GetItemAsync<Creator>(Data.PlayerName);
        Creator = c ?? new();
        Logger.LogInformation($"Creator loaded, {Creator.Characters.Count} characters in save.");
        NotifyOnLoad();
    }
    private async Task SaveCreatorAsync()
    {
        await Storage.SetItemAsync<Creator>(Data.PlayerName, Creator);
        NotifyOnSave();
    }
    private void NotifyOnLoad() => OnLoad?.Invoke(this, EventArgs.Empty);
    private void NotifyOnSave() => OnSave?.Invoke(this, EventArgs.Empty);
    #endregion Helpers
}
