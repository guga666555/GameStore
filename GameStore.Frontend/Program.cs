using GameStore.Frontend.Clients;
using GameStore.Frontend.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

// Throw error if the Url is not defined in appsettings.json.
var gameStoreApiUrl = builder.Configuration["GameStoreApiUrl"] ??
    throw new Exception("GameStoreApiUrl link is not set");

// Dependecy Injection HTTP;
builder.Services.AddHttpClient<GamesClients>
    (client => client.BaseAddress = new Uri(gameStoreApiUrl));

builder.Services.AddHttpClient<GenresClient>
    (client => client.BaseAddress = new Uri(gameStoreApiUrl));

builder.Services.AddHttpClient<PicturesClient>
    (client => client.BaseAddress = new Uri(gameStoreApiUrl));

builder.Services.AddHttpClient<PlataformClient>
    (client => client.BaseAddress = new Uri(gameStoreApiUrl));

builder.Services.AddHttpClient<ProductTypesClient>
    (client => client.BaseAddress = new Uri(gameStoreApiUrl));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.Run();
