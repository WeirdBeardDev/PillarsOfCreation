using Blazored.LocalStorage;

namespace Wbd.Pillars.Services;

public class GameService : IGameService
{
    #region Events
    public event EventHandler OnLoad = default!;
    public event EventHandler OnSave = default!;
    #endregion Events

    #region Properties
    public Creator Creator { get; private set; } = new();
    private ILocalStorageService Storage { get; set; }
    #endregion Properties

    #region Ctor
    public GameService(ILocalStorageService storageService) => Storage = storageService;
    #endregion Ctor

    #region Methods
    public async Task LoadAsync() => await LoadCreatorAsync();
    public async Task SaveAsync() => await SaveCreatorAsync();
    public async Task<bool> DoesSaveExist() => await Storage.ContainKeyAsync(Data.PlayerName);
    public async Task CreateSaveSlotAsync()
    {
        Creator = new();
        Console.WriteLine($"New empty character created.");
        await SaveCreatorAsync();
    }
    #endregion Methods

    #region Helpers
    private async Task LoadCreatorAsync()
    {
        var c = await Storage.GetItemAsync<Creator>(Data.PlayerName);
        Creator = c;
        Console.WriteLine($"Creator loaded, {Creator?.Characters.Count ?? 0} characters in save.");
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
