using System.ComponentModel.DataAnnotations;

namespace GameStore.Frontend.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }

    public class GenreSummary
    {
        public int Id {get; set;}
        public required string Name {get; set;}
    }

    public class GenreDetails
    {
        public int Id {get; set;}
        
        [Required] [StringLength(50)] 
        public required string Name {get; set;}
    }
}