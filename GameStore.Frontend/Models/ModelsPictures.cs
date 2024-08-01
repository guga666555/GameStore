using System.ComponentModel.DataAnnotations;

namespace GameStore.Frontend.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string PictureUrl {get; set;}
    }

    public class PictureSummary
    {
        public int Id {get; set;}
        public required string Name {get; set;}
        public required string PictureUrl {get; set;}
    }

    public class PictureDetails
    {
        public int Id {get; set;}
        
        [Required] [StringLength(50)] 
        public required string Name {get; set;}

        [Required] [StringLength(250)] 
        public required string PictureUrl {get; set;}
    }
}