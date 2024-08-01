using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients
{
    public class GamesClients(HttpClient httpClient)
    { 
        // Returns an empty array if the program did not found the "games" DB content.
        public async Task<GameSummary[]> GetGamesAsync()
            => await httpClient.GetFromJsonAsync<GameSummary[]>("games") ?? [];

        public async Task AddGamesAsync(GameDetails game) 
            => await httpClient.PostAsJsonAsync("games", game);

        public async Task<GameDetails> GetGameAsync(int id)
            => await httpClient.GetFromJsonAsync<GameDetails>($"games/{id}")
                ?? throw new Exception($"Could not find game with the id: {id}");

        public async Task UpdateGameAsync(GameDetails updatedGame)
            => await httpClient.PutAsJsonAsync($"games/{updatedGame.Id}", updatedGame);

        public async Task DeleteGameAsync(int id)
             => await httpClient.DeleteAsync($"games/{id}");
    }
}
