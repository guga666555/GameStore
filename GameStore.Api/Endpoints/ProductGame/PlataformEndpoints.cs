using GameStore.Api.Data;
using GameStore.Api.DTOS.ProductGame;
using GameStore.Api.Entities.ProductGame;
using GameStore.Api.Mapping.ProductGame;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints.ProductGame
{
    public static class PlataformEndpoints
    {
        private const string GetPlataformEndPointName = "GetPlataform";

        public static RouteGroupBuilder MapPlataformEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("plataforms");
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
                return await dbContext.Product_Games_Plataform
                    .Select(plataform => plataform.ToPlataformSummaryDTO())
                    .AsNoTracking()
                    .ToListAsync();
            });

            // Gets a single element in DB
            app.MapGet("/{plataformId}", async (int plataformId, GameStoreContext dbContext) =>
             {
                 EntityPlataform? plataformToGet = await dbContext.Product_Games_Plataform.FindAsync(plataformId);

                 return plataformToGet is null ?
                     Results.NotFound() : Results.Ok(plataformToGet.ToPlataformDetailsDTO());
             })
            .WithName(GetPlataformEndPointName);
        }

        private static void Endpoints_POST(RouteGroupBuilder app)
        {
            app.MapPost("/", async (CreatePlataformDTO newPlataform, GameStoreContext dbContext) =>
            {
                EntityPlataform plataform = newPlataform.PlataformToEntity();
                dbContext.Product_Games_Plataform.Add(plataform);
                await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute(
                    GetPlataformEndPointName,
                    new { plataformId = plataform.Id },
                    plataform.ToPlataformDetailsDTO()
                );
            });
        }

        private static void Endpoints_PUT(RouteGroupBuilder app)
        {
            app.MapPut("/{plataformId}", async (int plataformId, UpdatePlataformDTO updatedPlataform, GameStoreContext dbContext) =>
             {
                 var existingPlataform = await dbContext.Product_Games_Plataform.FindAsync(plataformId);

                 // If the current object doesnt exist or could not be found it will return
                 if (existingPlataform is null) return Results.NotFound();

                 dbContext.Entry(existingPlataform)
                     .CurrentValues
                     .SetValues(updatedPlataform.PlataformToEntity(plataformId));

                 await dbContext.SaveChangesAsync();

                 return Results.NoContent();
             });
        }

        private static void Endpoints_DELETE(RouteGroupBuilder app)
        {
            app.MapDelete("/{plataformId}", async (int plataformId, GameStoreContext dbContext) =>
            {
                await dbContext.Product_Games_Plataform.Where(plataform => plataform.Id == plataformId)
                   .ExecuteDeleteAsync();

                return Results.NoContent();
            });
        }
    }
}
