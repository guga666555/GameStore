using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.DTOS.ProductGame
{
    public record class CreateProductTypeDTO(
        [Required][StringLength(50)] string Name
    );

    public record class UpdateProductTypeDTO(
        [Required][StringLength(50)] string Name
    );

    public record class ProductTypeDetailsDTO(
        int Id,
        string Name
    );

    // CRUD: Read
    public record class ProductTypeSummaryDTO(
        int Id,
        string Name
    );
}