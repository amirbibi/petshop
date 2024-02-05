using Microsoft.AspNetCore.Http;
using PetShop.Validators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name must not exceed 100 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Age must be a non-negative number.")]
        public int? Age { get; set; }

        public string? PictureName { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(300, ErrorMessage = "Description must not exceed 300 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        [Display(Name = "Choose Category ")]
        public int CategoryId { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }

        [NotMapped]
        [ImageFileExtension(ErrorMessage = "File must be an image.")]
        public IFormFile? PictureFile { get; set; }

        [NotMapped]
        [ImageFileExtension(ErrorMessage = "File must be an image.")]
        public IFormFile? NewPictureFile { get; set; }
    }
}
