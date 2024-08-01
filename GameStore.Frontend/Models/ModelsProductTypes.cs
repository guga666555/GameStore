using System.ComponentModel.DataAnnotations;

namespace GameStore.Frontend.Models
{
    public class ProductTypes
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }

    public class ProductTypesSummary
    {
        public int Id {get; set;}
        public required string Name {get; set;}
    }

    public class ProductTypesDetails
    {
        public int Id {get; set;}

        [Required] [StringLength(50)]
         public required string Name {get; set;}
    }
}