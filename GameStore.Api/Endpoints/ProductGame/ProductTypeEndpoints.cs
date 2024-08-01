using GameStore.Api.Data;
using GameStore.Api.DTOS.ProductGame;
using GameStore.Api.Entities.ProductGame;
using GameStore.Api.Mapping.ProductGame;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints.ProductGame
{
    public static class ProductTypeEndpoints
    {
        private const string GetProductTypeEndPointName = "GetProductType";

        public static RouteGroupBuilder MapProductTypeEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("productTypes");
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
                return await dbContext.Product_Games_Type
                    .Select(productType => productType.ToProductTypeSummaryDTO())
                    .AsNoTracking()
                    .ToListAsync();
            });

            // Gets a single element in DB
            app.MapGet("/{productTypeId}", async (int productTypeId, GameStoreContext dbContext) =>
             {
                 EntityProductType? productTypeToGet = await dbContext.Product_Games_Type.FindAsync(productTypeId);

                 return productTypeToGet is null ?
                     Results.NotFound() : Results.Ok(productTypeToGet.ToProductTypeDetailsDTO());
             })
            .WithName(GetProductTypeEndPointName);
        }

        private static void Endpoints_POST(RouteGroupBuilder app)
        {
            app.MapPost("/", async (CreateProductTypeDTO newProductType, GameStoreContext dbContext) =>
            {
                EntityProductType productType = newProductType.ProductTypeToEntity();
                dbContext.Product_Games_Type.Add(productType);
                await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute(
                    GetProductTypeEndPointName,
                    new { productTypeId = productType.Id },
                    productType.ToProductTypeDetailsDTO()
                );
            });
        }

        private static void Endpoints_PUT(RouteGroupBuilder app)
        {
            app.MapPut("/{productTypeId}", async (int productTypeId, UpdateProductTypeDTO updatedProductType, GameStoreContext dbContext) =>
             {
                 var existingProductType = await dbContext.Product_Games_Type.FindAsync(productTypeId);

                 // If the current object doesnt exist or could not be found it will return
                 if (existingProductType is null) return Results.NotFound();

                 dbContext.Entry(existingProductType)
                     .CurrentValues
                     .SetValues(updatedProductType.ProductTypeToEntity(productTypeId));

                 await dbContext.SaveChangesAsync();

                 return Results.NoContent();
             });
        }

        private static void Endpoints_DELETE(RouteGroupBuilder app)
        {
            app.MapDelete("/{productTypeId}", async (int productTypeId, GameStoreContext dbContext) =>
            {
                await dbContext.Product_Games_Type.Where(productType => productType.Id == productTypeId)
                   .ExecuteDeleteAsync();

                return Results.NoContent();
            });
        }
    }
}
