using Microsoft.EntityFrameworkCore;
using GameStore.Api.Entities.ProductGame;

namespace GameStore.Api.Data
{
    public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
    {
        public DbSet<EntityProductGame> Product_Games => Set<EntityProductGame>();
        public DbSet<EntityGenre> Product_Games_Genres => Set<EntityGenre>();
        public DbSet<EntityProductType> Product_Games_Type => Set<EntityProductType>();
        public DbSet<EntityPlataform> Product_Games_Plataform => Set<EntityPlataform>();
        public DbSet<EntityPicture> Product_Games_Picture => Set<EntityPicture>();

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
        
}
