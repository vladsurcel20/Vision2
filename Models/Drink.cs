using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Day1.Models
{
    public class Drink
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Name length can't be more than 25.")]
        public string Name { get; set; }

        [StringLength(100, ErrorMessage = "Description length can't be more than 100.")]
        public string Description { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive integer.")]
        public int Price { get; set; }
    }
}

