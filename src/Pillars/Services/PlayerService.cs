using Blazored.LocalStorage;
using Wbd.Pillars.ClassLib.DataStore;

namespace Wbd.Pillars.Services;

public class PlayerService(SaveService saveService, ILogger<PlayerService> logger)
{
    #region Members
    private SaveService _saveService = saveService;
    private ILogger _logger = logger;
    #endregion

    #region Properties
    public Player Player { get; private set; } = new();
    // public Character ActiveCharacter => Player.Characters[Player.LastActiveSlot];
    public async Task<bool> DoesSaveExistAsync() => await _saveService.ContainKeyAsync(Data.PlayerName);
    #endregion Properties

    #region Methods
    public async Task CreateSlotsAsync()
    {
        await _saveService.SaveAsync<Player>(Data.PlayerName, Player);
        _logger.LogInformation($"Player slots created, {Player.Characters.Count} character slots in save.");
    }
    public async Task DeleteSlotsAsync()
    {
        await _saveService.DeleteAsync(Data.PlayerName);
        _logger.LogInformation($"Player slots deleted, {Player.Characters.Count} character slots in save.");
    }
    public async Task<Player> LoadPlayerAsync()
    {
        Player = await _saveService.LoadAsync<Player>(Data.PlayerName);
        _logger.LogInformation($"Player loaded, {Player.Characters.Count} character slots in save.");
        return Player;
    }
    public async Task SavePlayerAsync()
    {
        await _saveService.SaveAsync<Player>(Data.PlayerName, Player);
        _logger.LogInformation($"Player saved, {Player.Characters.Count} character slots in save.");
    }
    #endregion Methods
}