using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Services;

namespace PetShop.Controllers
{
    public class NewAnimalController : Controller
    {
        private readonly IAnimalService _animalService;
        private readonly ICategoryService _categoryService;

        public NewAnimalController(IAnimalService animalService, ICategoryService categoryService)
        {
            _animalService = animalService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Categories = await _categoryService.GetDistinctCategoriesAsync();
            return View();
        }

        public async Task<IActionResult> Edit(Animal animal)
        {
            ViewBag.Categories = await _categoryService.GetDistinctCategoriesAsync();
            return View("Index", animal);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Animal model)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Failed");

                ViewBag.Categories = await _categoryService.GetDistinctCategoriesAsync();
                return View("Index", model);
            }

            var animalInDb = await _animalService.GetAnimalByIdAsync(model.AnimalId);

            // Create Animal
            if (animalInDb is null)
            {
                if (model.PictureFile is not null)
                    await UploadImage(model);
                else // default image
                {
                    var res = await _categoryService.GetCategoryByCategoryIdAsync(model.CategoryId);
                    model.PictureName = @$"/default/{res.Name!.ToLower()}-default.jpg";
                }

                await _animalService.InsertAnimalAsync(model);
                return RedirectToAction("Index", "Administrator");
            }

            // Edit Animal Picture
            else if (model.NewPictureFile is not null)
            {
                await UploadImage(model, true);
            }

            // Edit the rest props
            await _animalService.EditAnimalAsync(model);
            return RedirectToAction("Index", "Administrator");
        }

        private static async Task UploadImage(Animal model, bool isImageReplace = false)
        {
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "animals");

            var fileToUpload = isImageReplace ? model.NewPictureFile : model.PictureFile;

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(fileToUpload!.FileName)}";
            var filePath = Path.Combine(uploadPath, fileName);

            model.PictureName = fileName;

            using var fileStream = new FileStream(filePath, FileMode.Create);
            await fileToUpload!.CopyToAsync(fileStream);
        }
    }
}
