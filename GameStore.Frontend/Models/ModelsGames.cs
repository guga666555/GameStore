using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using GameStore.Frontend.Converters;

namespace GameStore.Frontend.Models
{
    public class GameSummary
    {
        public int Id {get; set;}
        public required string Name {get; set;}
        public required string Genre {get; set;}
        public required string Picture {get; set;}
        public required string Plataform {get; set;}
        public required string ProductType {get; set;}
        public decimal Price {get; set;} 
        public DateOnly ReleaseDate {get; set;}
    }

    public class GameDetails
    {
        public int Id {get; set;}
        [Required] [StringLength(50)]
    
        public required string Name {get; set;}

        [Required(ErrorMessage = ("The Genre field is required."))] 
        [JsonConverter(typeof(StringConverter))]
        public string? GenreId {get; set;}

        [Required(ErrorMessage = ("The Plataform field is required."))] 
        [JsonConverter(typeof(StringConverter))]
        public string? PlataformId {get; set;}

        [Required(ErrorMessage = ("The Picture field is required."))] 
        [JsonConverter(typeof(StringConverter))]
        public string? PictureId {get; set;}

        [Required(ErrorMessage = ("The Product field is required."))] 
        [JsonConverter(typeof(StringConverter))]
        public string? ProductTypeId {get; set;}

        [Range(1, 100)] 
        public decimal Price {get; set;} 

        public DateOnly ReleaseDate {get; set;}
    }
}