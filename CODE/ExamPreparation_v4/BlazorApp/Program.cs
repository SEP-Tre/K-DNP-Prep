using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp;
using WASM_.Pages;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IClientInjector,ClientInjector>();

builder.Services.AddScoped
    (sp => new HttpClient { BaseAddress = new Uri("https://localhost:7230") });
await builder.Build().RunAsync();