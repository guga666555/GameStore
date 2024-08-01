using GameStore.Api.DTOS.ProductGame;
using GameStore.Api.Entities.ProductGame;

namespace GameStore.Api.Mapping.ProductGame
{
    public static class MappingObjectProductType
    {
        public static EntityProductType ProductTypeToEntity(this CreateProductTypeDTO productType)
        {

            return new EntityProductType()
            {
                Name = productType.Name
            };
        }

        public static EntityProductType ProductTypeToEntity(this UpdateProductTypeDTO productType, int id)
        {

            return new EntityProductType()
            {
                Id = id,
                Name = productType.Name
            };
        }

        public static ProductTypeDetailsDTO ToProductTypeDetailsDTO(this EntityProductType productType)
        {
            return new(
                productType.Id,
                productType.Name
            );
        }

        public static ProductTypeSummaryDTO ToProductTypeSummaryDTO(this EntityProductType productType)
        {
            return new(
                productType.Id,
                productType.Name
            );
        }
    }
}
