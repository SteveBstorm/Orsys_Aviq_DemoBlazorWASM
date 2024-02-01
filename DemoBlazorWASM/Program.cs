using DemoBlazorWASM;
using DemoBlazorWASM.Security;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7200/api/") });

builder.Services.AddAuthorizationCore();
builder.Services.AddSingleton<AuthenticationStateProvider, MyStateProvider>();
await builder.Build().RunAsync();

// https://github.com/SteveBstorm/Orsys_Aviq_DemoBlazorWASM
