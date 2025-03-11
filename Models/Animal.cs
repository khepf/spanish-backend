using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class Animal
    {
        public int Id { get; set; }
        
        [Required]
        public required string Name { get; set; }
        
        [Required]
        public required string Translation { get; set; }
        
        [Required]
        public required string ImageLocation { get; set; }
    }
}