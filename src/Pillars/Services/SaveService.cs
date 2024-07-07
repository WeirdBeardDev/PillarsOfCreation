using Blazored.LocalStorage;

namespace Wbd.Pillars.Services;

public class SaveService(ILocalStorageService storageService, ILogger<SaveService> logger)
{
    #region Members
    private ILocalStorageService _storage = storageService;
    private ILogger _logger = logger;
    #endregion

    #region Methods
    public async Task<bool> ContainKeyAsync(string key)
    {
        var result = await _storage.ContainKeyAsync(key);
        _logger.LogInformation($"Key `{key}` found: {result}.");
        return result;
    }
    public async Task<T> LoadAsync<T>(string key) where T : class, new()
    {
        var data = await _storage.GetItemAsync<T>(key) ?? new();
        _logger.LogInformation($"Data loaded from {key}.");
        return data;
    }
    public async Task<T> SaveAsync<T>(string key, T data) where T : class
    {
        await _storage.SetItemAsync(key, data);
        _logger.LogInformation($"Data saved to {key}.");
        return data;
    }
    public async Task DeleteAsync(string key)
    {
        await _storage.RemoveItemAsync(key);
        _logger.LogInformation($"Data deleted from {key}.");
    }
    #endregion Methods
}