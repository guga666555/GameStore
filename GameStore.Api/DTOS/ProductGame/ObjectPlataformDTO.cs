using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.DTOS.ProductGame
{
    public record class CreatePlataformDTO(
        [Required][StringLength(50)] string Name
    );

    public record class UpdatePlataformDTO(
        [Required][StringLength(50)] string Name
    );

    public record class PlataformDetailsDTO(
        int Id,
        string Name
    );

    // CRUD: Read
    public record class PlataformSummaryDTO(
        int Id,
        string Name
    );
}