using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients
{
    public class PicturesClient(HttpClient httpClient)
    {
        public async Task<PictureSummary[]> GetPicturesAsync()
            => await httpClient.GetFromJsonAsync<PictureSummary[]>("pictures") ?? [];

        public async Task AddPictureAsync(PictureDetails picture) 
            => await httpClient.PostAsJsonAsync("pictures", picture);

        public async Task<PictureDetails> GetPictureAsync(int id)
            => await httpClient.GetFromJsonAsync<PictureDetails>($"pictures/{id}")
                ?? throw new Exception($"Could not find pictures with the id: {id}");

        public async Task UpdatePictureAsync(PictureDetails updatedPicture)
            => await httpClient.PutAsJsonAsync($"pictures/{updatedPicture.Id}", updatedPicture);

        public async Task DeletePictureAsync(int id)
             => await httpClient.DeleteAsync($"pictures/{id}");
    }
}
