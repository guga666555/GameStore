using GameStore.Api.Data;
using GameStore.Api.Endpoints.ProductGame;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();

app.MapGamesEndpoints();
app.MapGenresEndpoints();
app.MapPicturesEndpoints();
app.MapPlataformEndpoints();
app.MapProductTypeEndpoints();

await app.MigrateDbAsync();

app.Run();
