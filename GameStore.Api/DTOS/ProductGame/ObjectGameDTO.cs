using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.DTOS.ProductGame
{
    // CRUD: Create
    public record class CreateGameDTO(
        [Required][StringLength(50)] string Name,
        [Range(1, 100)] decimal Price,
        DateOnly ReleaseDate,
        int GenreId,
        int PictureId,
        int PlataformId,
        int ProductTypeId
    );

    // CRUD: Update
    public record class UpdateGameDTO(
        [Required][StringLength(50)] string Name,
        [Range(1, 100)] decimal Price,
        DateOnly ReleaseDate,
        int GenreId,
        int PictureId,
        int PlataformId,
        int ProductTypeId
    );

    // CRUD: Read
    public record class GameDetailsDTO(
        int Id,
        string Name,
        decimal Price,
        DateOnly ReleaseDate,
        int PictureId,
        int PlataformId,
        int ProductTypeId,
        int GenreId
    );

    // CRUD: Read
    public record class GameSummaryDTO(
        int Id,
        string Name,
        decimal Price,
        DateOnly ReleaseDate,
        string Picture,
        string Plataform,
        string ProductType,
        string Genre
    );
}