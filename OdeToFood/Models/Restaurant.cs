using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required, MinLength(1), MaxLength(80)]
        [Display(Name = "Restaurant name")]
        public string Name { get; set; }

        public CuisineType Cuisine { get; set; }
    }
}
