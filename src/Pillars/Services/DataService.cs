namespace Wbd.Pillars.Services;

using System.Text.Json;
using Wbd.Pillars.ClassLib.DataStore;

public class DataService
{
    #region Members
    private readonly ILogger _logger;
    private readonly HttpClient _http;
    #endregion

    #region Properties
    public List<Item> Items { get; private set; } = [];
    #endregion Properties

    #region Ctor
    public DataService(ILogger<DataService> logger, HttpClient http)
    {
        _logger = logger;
        _http = http;
    }
    #endregion Ctor

    #region Methods
    public async Task LoadDbAsync()
    {
        Items = await LoadItemsAsync();
        _logger.LogInformation($"DataService contains {Items.Count} items.");
    }
    public Item GetItem(int id)
    {
        var item = Items.FirstOrDefault(i => i.Id == id);
        if (item == null)
        {
            _logger.LogWarning($"Item {id} not found.");
            return Items.First();
        }
        return item;
    }
    #endregion Methods

    #region Helpers
    private async Task<List<Item>> LoadItemsAsync()
    {
        try
        {
            var itemData = await _http.GetStringAsync("/data/itemDb.json");
            var opt = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<List<Item>>(itemData, opt) ?? GetErrorItems();
        }
        catch (JsonException ex)
        {
            _logger.LogError(ex, "Error deserializing item data.");
            return GetErrorItems();
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Error loading item data.");
            return GetErrorItems();
        }
    }
    private static List<Item> GetErrorItems() => [new Item(1, "Unknown", "Something weird happened..."),];
    #endregion Helpers
}