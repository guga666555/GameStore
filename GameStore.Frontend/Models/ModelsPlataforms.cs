using System.ComponentModel.DataAnnotations;

namespace GameStore.Frontend.Models
{
    public class Plataform
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }

    public class PlataformSummary
    {
        public int Id {get; set;}
        public required string Name {get; set;}
    }

    public class PlataformDetails
    {
        public int Id {get; set;}
        
        [Required] [StringLength(50)] 
        public required string Name {get; set;}
    }
}