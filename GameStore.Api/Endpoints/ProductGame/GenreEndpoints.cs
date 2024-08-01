using GameStore.Api.Data;
using GameStore.Api.DTOS.ProductGame;
using GameStore.Api.Entities.ProductGame;
using GameStore.Api.Mapping.ProductGame;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints.ProductGame
{
    public static class GenreEndpoints
    {
        private const string GetGenreEndPointName = "GetGenre";

        public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("genres");
            Endpoints_GET(group);
            Endpoints_POST(group);
            Endpoints_PUT(group);
            Endpoints_DELETE(group);
            return group;
        }

        private static void Endpoints_GET(RouteGroupBuilder app)
        {
            app.MapGet("/", async (GameStoreContext dbContext) =>
            {
                return await dbContext.Product_Games_Genres
                    .Select(genre => genre.ToGenreSummaryDTO())
                    .AsNoTracking()
                    .ToListAsync();
            });

            // Gets a single element in DB
            app.MapGet("/{genreId}", async (int genreId, GameStoreContext dbContext) =>
             {
                 EntityGenre? genreToGet = await dbContext.Product_Games_Genres.FindAsync(genreId);

                 return genreToGet is null ?
                     Results.NotFound() : Results.Ok(genreToGet.ToGenreDetailsDTO());
             })
            .WithName(GetGenreEndPointName);
        }

        private static void Endpoints_POST(RouteGroupBuilder app)
        {
            app.MapPost("/", async (CreateGenreDTO newGenre, GameStoreContext dbContext) =>
            {
                EntityGenre genre = newGenre.GenreToEntity();
                dbContext.Product_Games_Genres.Add(genre);
                await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute(
                    GetGenreEndPointName,
                    new { genreId = genre.Id },
                    genre.ToGenreDetailsDTO()
                );
            });
        }

        private static void Endpoints_PUT(RouteGroupBuilder app)
        {
            app.MapPut("/{genreId}", async (int genreId, UpdateGenreDTO updatedGenre, GameStoreContext dbContext) =>
             {
                 var existingGenre = await dbContext.Product_Games_Genres.FindAsync(genreId);

                 // If the current object doesnt exist or could not be found it will return
                 if (existingGenre is null) return Results.NotFound();

                 dbContext.Entry(existingGenre)
                     .CurrentValues
                     .SetValues(updatedGenre.GenreToEntity(genreId));

                 await dbContext.SaveChangesAsync();

                 return Results.NoContent();
             });
        }

        private static void Endpoints_DELETE(RouteGroupBuilder app)
        {
            app.MapDelete("/{genreId}", async (int genreId, GameStoreContext dbContext) =>
            {
                await dbContext.Product_Games_Genres.Where(genre => genre.Id == genreId)
                   .ExecuteDeleteAsync();

                return Results.NoContent();
            });
        }
    }
}
