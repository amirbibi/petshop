using System.ComponentModel.DataAnnotations;

namespace PetShop.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }

        [Required]
        public string? Content { get; set; }

        public string? UserName { get; set; }
    }
}
