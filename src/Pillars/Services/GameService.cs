using System.Reflection;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Wbd.Pillars.ClassLib.DataStore;

namespace Wbd.Pillars.Services;

public class GameService(ILocalStorageService storageService, ILogger<GameService> logger, IWebAssemblyHostEnvironment hostEnvironment) : IGameService
{
    // TODO Create a DataService to handle loading/saving the game
    // TODO Create a CharacterService to handle the character data
    // TODO Move the relevant methods from this class to the new services
    #region Events
    public event EventHandler OnLoad = default!;
    public event EventHandler OnSave = default!;
    #endregion Events

    #region Properties
    public Creator Creator { get; private set; } = new();
    public string Version => $"v{Assembly.GetExecutingAssembly().GetName().Version?.ToString(3)}{(EnvironmentName != string.Empty ? "." + EnvironmentName : "")}" ?? "unknown";
    public TimerService Timer { get; private set; } = new();
    private ILocalStorageService Storage { get; set; } = storageService;
    private ILogger Logger { get; set; } = logger;
    private IWebAssemblyHostEnvironment HostEnvironment { get; set; } = hostEnvironment;
    private string EnvironmentName => HostEnvironment.IsDevelopment() ? "dev" : "";
    #endregion Properties

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
    public async Task StartGameAsync()
    {
        await LoadAsync();
        Logger.LogInformation($"Game started, {Creator.Characters.Count} character slots in save.");
    }
    #endregion Methods

    #region Helpers
    private async Task LoadCreatorAsync()
    {
        var c = await Storage.GetItemAsync<Creator>(Data.PlayerName);
        Creator = c ?? new();
        Logger.LogInformation($"Creator loaded, {Creator.Characters.Count} character slots in save.");
        NotifyOnLoad();

        // TODO setup other pre-game services here

        // Start the game timer
        // Timer.Start();
        // Timer.OnTick += (sender, e) => Logger.LogInformation("Timer ticked.");
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
