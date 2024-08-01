using GameStore.Api.DTOS.ProductGame;
using GameStore.Api.Entities.ProductGame;

namespace GameStore.Api.Mapping.ProductGame
{
    public static class MappingObjectPicture
    {
        public static EntityPicture PictureToEntity(this CreatePictureDTO picture)
        {

            return new EntityPicture()
            {
                Name = picture.Name,
                PictureUrl = picture.PictureUrl
            };
        }

        public static EntityPicture PictureToEntity(this UpdatePictureDTO picture, int id)
        {

            return new EntityPicture()
            {
                Id = id,
                Name = picture.Name,
                PictureUrl = picture.PictureUrl
            };
        }

        public static PictureDetailsDTO ToPictureDetailsDTO(this EntityPicture picture)
        {
            return new(
                picture.Id,
                picture.Name,
                picture.PictureUrl
            );
        }

        public static PictureSummaryDTO ToPictureSummaryDTO(this EntityPicture picture)
        {
            return new(
                picture.Id,
                picture.Name,
                picture.PictureUrl
            );
        }
    }
}
