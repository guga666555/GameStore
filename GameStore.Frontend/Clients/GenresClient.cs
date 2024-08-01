using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients
{
    public class GenresClient(HttpClient httpClient)
    {
        public async Task<GenreSummary[]> GetGenresAsync()
            => await httpClient.GetFromJsonAsync<GenreSummary[]>("genres") ?? [];

        public async Task AddGenreAsync(GenreDetails genre) 
            => await httpClient.PostAsJsonAsync("genres", genre);

        public async Task<GenreDetails> GetGenreAsync(int id)
            => await httpClient.GetFromJsonAsync<GenreDetails>($"genres/{id}")
                ?? throw new Exception($"Could not find genres with the id: {id}");

        public async Task UpdateGenreAsync(GenreDetails updatedGenre)
            => await httpClient.PutAsJsonAsync($"genres/{updatedGenre.Id}", updatedGenre);

        public async Task DeleteGenreAsync(int id)
             => await httpClient.DeleteAsync($"genres/{id}");
    }
}
