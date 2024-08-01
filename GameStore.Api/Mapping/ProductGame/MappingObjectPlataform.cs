using GameStore.Api.DTOS.ProductGame;
using GameStore.Api.Entities.ProductGame;

namespace GameStore.Api.Mapping.ProductGame
{
    public static class MappingObjectPlataform
    {
        public static EntityPlataform PlataformToEntity(this CreatePlataformDTO plataform)
        {

            return new EntityPlataform()
            {
                Name = plataform.Name
            };
        }

        public static EntityPlataform PlataformToEntity(this UpdatePlataformDTO plataform, int id)
        {

            return new EntityPlataform()
            {
                Id = id,
                Name = plataform.Name
            };
        }

        public static PlataformDetailsDTO ToPlataformDetailsDTO(this EntityPlataform plataform)
        {
            return new(
                plataform.Id,
                plataform.Name
            );
        }

        public static PlataformSummaryDTO ToPlataformSummaryDTO(this EntityPlataform plataform)
        {
            return new(
                plataform.Id,
                plataform.Name
            );
        }
    }
}
