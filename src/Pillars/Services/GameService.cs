using System.Reflection;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Wbd.Pillars.ClassLib.DataStore;

namespace Wbd.Pillars.Services;

public class GameService(SaveService saveService, ILogger<GameService> logger, IWebAssemblyHostEnvironment hostEnvironment, TimerService timer, PlayerService player, DataService dataService) : IGameService
{
    #region Properties
    private ILogger Logger { get; set; } = logger;
    private IWebAssemblyHostEnvironment HostEnvironment { get; set; } = hostEnvironment;
    private string version = Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "unknown";
    private string EnvironmentName => HostEnvironment.IsDevelopment() ? ".dev" : "";

    public string Version => $"v{version}{EnvironmentName}";
    public DataService Data { get; private set; } = dataService;
    public PlayerService Player { get; private set; } = player;
    public SaveService Storage { get; private set; } = saveService;
    public TimerService Timer { get; private set; } = timer;
    #endregion Properties

    #region Methods
    public async Task StartGameAsync()
    {
        await Data.LoadDbAsync();
        // TODO make sure all services are started and ready
        Logger.LogInformation($"Game started.");
    }
    #endregion Methods
}
