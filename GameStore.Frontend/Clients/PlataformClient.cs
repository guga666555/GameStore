using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients
{
    public class PlataformClient(HttpClient httpClient)
    {
        public async Task<PlataformSummary[]> GetPlataformsAsync()
            => await httpClient.GetFromJsonAsync<PlataformSummary[]>("plataforms") ?? [];

        public async Task AddPlataformAsync(PlataformDetails plataform) 
            => await httpClient.PostAsJsonAsync("plataforms", plataform);

        public async Task<PlataformDetails> GetPlataformAsync(int id)
            => await httpClient.GetFromJsonAsync<PlataformDetails>($"plataforms/{id}")
                ?? throw new Exception($"Could not find plataforms with the id: {id}");

        public async Task UpdatePlataformAsync(PlataformDetails updatedPlataform)
            => await httpClient.PutAsJsonAsync($"plataforms/{updatedPlataform.Id}", updatedPlataform);

        public async Task DeletePlataformAsync(int id)
             => await httpClient.DeleteAsync($"plataforms/{id}");
    }
}
