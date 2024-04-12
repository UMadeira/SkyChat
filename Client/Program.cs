using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using MudBlazor;
using MudBlazor.Services;

using SkyChat.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>( "#app" );
builder.RootComponents.Add<HeadOutlet>( "head::after" );

builder.Services.AddHttpClient( "SkyChat.ServerAPI", client => client.BaseAddress = new Uri( builder.HostEnvironment.BaseAddress ) );

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped( sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient( "SkyChat.ServerAPI" ) );

builder.Services.AddMudServices( config => {
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopCenter;
} );

builder.Services.AddScoped<AuthenticationStateProvider, MockAuthenticationStateProvier>();

await builder.Build().RunAsync();
