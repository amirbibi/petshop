using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Validators
{
    public class ImageFileExtensionAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) return true;

            if (value is IFormFile file)
            {
                string[] allowedExtensions = [".jpg", ".jpeg", ".png", ".gif"];
                string extension = Path.GetExtension(file!.FileName).ToLower();

                if (allowedExtensions.Contains(extension))
                    return true;
            }
            return false;
        }
    }
}
