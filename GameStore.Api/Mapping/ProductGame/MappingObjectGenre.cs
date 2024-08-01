using GameStore.Api.DTOS.ProductGame;
using GameStore.Api.Entities.ProductGame;

namespace GameStore.Api.Mapping.ProductGame
{
    public static class MappingObjectGenre
    {
        public static EntityGenre GenreToEntity(this CreateGenreDTO genre)
        {

            return new EntityGenre()
            {
                Name = genre.Name,
            };
        }

        public static EntityGenre GenreToEntity(this UpdateGenreDTO genre, int id)
        {

            return new EntityGenre()
            {
                Id = id,
                Name = genre.Name,
            };
        }

        public static GenreDetailsDTO ToGenreDetailsDTO(this EntityGenre genre)
        {
            return new(
                genre.Id,
                genre.Name
            );
        }

        public static GenreSummaryDTO ToGenreSummaryDTO(this EntityGenre genre)
        {
            return new(
                genre.Id,
                genre.Name
            );
        }
    }
}
