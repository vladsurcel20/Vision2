using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Dog
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Range(1, 99)]
        public int Age { get; set; }
        public string Color { get; set; }

    }
}
