using GameStore.Api.Data;
using GameStore.Api.DTOS.ProductGame;
using GameStore.Api.Entities.ProductGame;
using GameStore.Api.Mapping.ProductGame;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints.ProductGame
{
    public static class PictureEndpoints
    {
        private const string GetPictureEndPointName = "GetPicture";

        public static RouteGroupBuilder MapPicturesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("pictures");
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
                return await dbContext.Product_Games_Picture
                    .Select(picture => picture.ToPictureSummaryDTO())
                    .AsNoTracking()
                    .ToListAsync();
            });

            // Gets a single element in DB
            app.MapGet("/{pictureId}", async (int pictureId, GameStoreContext dbContext) =>
             {
                 EntityPicture? pictureToGet = await dbContext.Product_Games_Picture.FindAsync(pictureId);

                 return pictureToGet is null ?
                     Results.NotFound() : Results.Ok(pictureToGet.ToPictureDetailsDTO());
             })
            .WithName(GetPictureEndPointName);
        }

        private static void Endpoints_POST(RouteGroupBuilder app)
        {
            app.MapPost("/", async (CreatePictureDTO newPicture, GameStoreContext dbContext) =>
            {
                EntityPicture picture = newPicture.PictureToEntity();
                dbContext.Product_Games_Picture.Add(picture);
                await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute(
                    GetPictureEndPointName,
                    new { pictureId = picture.Id },
                    picture.ToPictureDetailsDTO()
                );
            });
        }

        private static void Endpoints_PUT(RouteGroupBuilder app)
        {
            app.MapPut("/{pictureId}", async (int pictureId, UpdatePictureDTO updatedPicture, GameStoreContext dbContext) =>
             {
                 var existingPicture = await dbContext.Product_Games_Picture.FindAsync(pictureId);

                 // If the current object doesnt exist or could not be found it will return
                 if (existingPicture is null) return Results.NotFound();

                 dbContext.Entry(existingPicture)
                     .CurrentValues
                     .SetValues(updatedPicture.PictureToEntity(pictureId));

                 await dbContext.SaveChangesAsync();

                 return Results.NoContent();
             });
        }

        private static void Endpoints_DELETE(RouteGroupBuilder app)
        {
            app.MapDelete("/{pictureId}", async (int pictureId, GameStoreContext dbContext) =>
            {
                await dbContext.Product_Games_Picture.Where(picture => picture.Id == pictureId)
                   .ExecuteDeleteAsync();

                return Results.NoContent();
            });
        }
    }
}
