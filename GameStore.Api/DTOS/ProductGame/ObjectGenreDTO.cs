using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.DTOS.ProductGame
{
    public record class CreateGenreDTO(
        [Required][StringLength(50)] string Name
    );

    public record class UpdateGenreDTO(
        [Required][StringLength(50)] string Name
    );

    public record class GenreDetailsDTO(
        int Id,
        string Name
    );

    // CRUD: Read
    public record class GenreSummaryDTO(
        int Id,
        string Name
    );
}