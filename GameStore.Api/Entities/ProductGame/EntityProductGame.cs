namespace GameStore.Api.Entities.ProductGame
{
    public class EntityProductGame : EntityProduct
    {
        public decimal Price { get; set; }
        public DateOnly ReleaseDate { get; set; } 
    
        public int PictureId { get; set; } // FK
        public EntityPicture? Picture { get; set; }

        public int PlataformId { get; set; } // FK
        public EntityPlataform? Plataform { get; set; }
    
        public int ProductTypeId { get; set; } // FK
        public EntityProductType? ProductType { get; set; }
    
        public int GenreId { get; set; } // FK
        public EntityGenre? Genre { get; set; }
    }
}
