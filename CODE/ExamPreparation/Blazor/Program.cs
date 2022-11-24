using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazor;
using HttpClients.Implementations;
using HttpClients.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped
    (sp => new HttpClient { BaseAddress = new Uri("https://localhost:7145") });

builder.Services.AddScoped<IChildService, ChildHttpClient>();

await builder.Build().RunAsync();