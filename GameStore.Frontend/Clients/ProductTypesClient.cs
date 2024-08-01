using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients
{
    public class ProductTypesClient(HttpClient httpClient)
    {
        public async Task<ProductTypesSummary[]> GetProductTypeAsync()
            => await httpClient.GetFromJsonAsync<ProductTypesSummary[]>("productTypes") ?? [];

        public async Task AddProductTypeAsync(ProductTypesDetails productType) 
            => await httpClient.PostAsJsonAsync("productTypes", productType);

        public async Task<ProductTypesDetails> GetProductTypeAsync(int id)
            => await httpClient.GetFromJsonAsync<ProductTypesDetails>($"productTypes/{id}")
                ?? throw new Exception($"Could not find product types with the id: {id}");

        public async Task UpdateProductTypeAsync(ProductTypesDetails updatedProductType)
            => await httpClient.PutAsJsonAsync($"productTypes/{updatedProductType.Id}", updatedProductType);

        public async Task DeleteProductTypeAsync(int id)
             => await httpClient.DeleteAsync($"productTypes/{id}");
    }
}
