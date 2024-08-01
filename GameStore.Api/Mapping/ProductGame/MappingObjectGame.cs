using GameStore.Api.DTOS.ProductGame;
using GameStore.Api.Entities.ProductGame;

namespace GameStore.Api.Mapping.ProductGame
{
    public static class MappingObjectGame
    {
        public static EntityProductGame GameToEntity(this CreateGameDTO game)
        {
            return new EntityProductGame()
            {
                Name = game.Name,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate,
                PlataformId = game.PlataformId,
                PictureId = game.PictureId,
                ProductTypeId = game.ProductTypeId,
                GenreId = game.GenreId
            };
        }

        public static EntityProductGame GameToEntity(this UpdateGameDTO game, int id)
        {
            return new EntityProductGame()
            {
                Id = id,
                Name = game.Name,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate,
                PictureId = game.PictureId,
                PlataformId = game.PlataformId,
                ProductTypeId = game.ProductTypeId,
                GenreId = game.GenreId
            };
        }

        public static GameDetailsDTO ToGameDetailsDTO(this EntityProductGame game)
        {
            return new(
                game.Id,
                game.Name,
                game.Price,
                game.ReleaseDate,
                game.PictureId,
                game.PlataformId,
                game.ProductTypeId,
                game.GenreId
            );
        }

        public static GameSummaryDTO ToGameSummaryDTO(this EntityProductGame game)
        {
            return new(
                game.Id,
                game.Name,
                game.Price,
                game.ReleaseDate,
                game.Picture!.Name,
                game.Plataform!.Name,
                game.ProductType!.Name,
                game.Genre!.Name
            );
        }
    }
}
