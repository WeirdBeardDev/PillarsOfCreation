using Blazor.Extensions.Logging;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Logging.AddBrowserConsole();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<SaveService>();
builder.Services.AddScoped<TimerService>();
builder.Services.AddScoped<PlayerService>();
builder.Services.AddScoped<DataService>();


builder.Services.AddScoped<IGameService, GameService>();

await builder.Build().RunAsync();
