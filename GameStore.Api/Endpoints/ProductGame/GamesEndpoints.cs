using GameStore.Api.Data;
using GameStore.Api.DTOS.ProductGame;
using GameStore.Api.Entities.ProductGame;
using GameStore.Api.Mapping.ProductGame;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints.ProductGame
{
    public static class GamesEndpoints
    {
        private const string GetGameEndPointName = "GetGame";

        public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("games").WithParameterValidation();
            Endpoints_GET(group);
            Endpoints_POST(group);
            Endpoints_PUT(group);
            Endpoints_DELETE(group);
            return group;
        }

        private static void Endpoints_GET(RouteGroupBuilder app)
        {
            // Gets all elements in DB
            app.MapGet("/", async (GameStoreContext dbContext) =>
            {
                return await dbContext.Product_Games
                    .Include(game => game.Picture)
                    .Include(game => game.Plataform)
                    .Include(game => game.ProductType)
                    .Include(game => game.Genre)
                    .Select(game => game.ToGameSummaryDTO())
                    .AsNoTracking()
                    .ToListAsync();
            });

            // Gets a single element in DB
            app.MapGet("/{gameId}", async (int gameId, GameStoreContext dbContext) =>
             {
                 EntityProductGame? gameToGet = await dbContext.Product_Games.FindAsync(gameId);

                 return gameToGet is null ?
                    Results.NotFound() : Results.Ok(gameToGet.ToGameDetailsDTO());
             })
            .WithName(GetGameEndPointName);
        }

        private static void Endpoints_POST(RouteGroupBuilder app)
        {
            app.MapPost("/", async (CreateGameDTO newGame, GameStoreContext dbContext) =>
            {
                EntityProductGame game = newGame.GameToEntity();
                dbContext.Product_Games.Add(game);
                await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute(
                    GetGameEndPointName,
                    new { gameId = game.Id },
                    game.ToGameDetailsDTO()
                );
            });
        }

        private static void Endpoints_PUT(RouteGroupBuilder app)
        {
            app.MapPut("/{gameId}", async (int gameId, UpdateGameDTO updatedGame, GameStoreContext dbContext) =>
             {
                 var existingGame = await dbContext.Product_Games.FindAsync(gameId);

                 // If the current object doesnt exist or could not be found it will return
                 if (existingGame is null) return Results.NotFound();

                 dbContext.Entry(existingGame)
                     .CurrentValues
                     .SetValues(updatedGame.GameToEntity(gameId));

                 await dbContext.SaveChangesAsync();

                 return Results.NoContent();
             });
        }

        private static void Endpoints_DELETE(RouteGroupBuilder app)
        {
            app.MapDelete("/{gameId}", async (int gameId, GameStoreContext dbContext) =>
            {
                await dbContext.Product_Games.Where(game => game.Id == gameId)
                   .ExecuteDeleteAsync();

                return Results.NoContent();
            });
        }
    }
}
