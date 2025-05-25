using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Wbd.Pillars.DevTools.Logging;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Logging configuration
builder.Logging.ClearProviders().AddInMemoryLogger();

// var logLevel = builder.HostEnvironment.IsDevelopment() ? LogLevel.Information : LogLevel.Error;
// builder.Logging.SetMinimumLevel(logLevel);

// Root components and services configuration
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<SaveService>();
builder.Services.AddScoped<TimerService>();
builder.Services.AddScoped<PlayerService>();
builder.Services.AddScoped<DataService>();


builder.Services.AddScoped<IGameService, GameService>();

// Last one
await builder.Build().RunAsync();
