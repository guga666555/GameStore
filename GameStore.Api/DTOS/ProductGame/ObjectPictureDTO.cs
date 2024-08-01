using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.DTOS.ProductGame
{
    public record class CreatePictureDTO(
        [Required][StringLength(50)] string Name,
        [Required][StringLength(250)] string PictureUrl
    );

    public record class UpdatePictureDTO(
        [Required][StringLength(50)] string Name,
        [Required][StringLength(250)] string PictureUrl
    );

    public record class PictureDetailsDTO(
        int Id,
        string Name,
        string PictureUrl
    );

    // CRUD: Read
    public record class PictureSummaryDTO(
        int Id,
        string Name,
        string PictureUrl
    );
}