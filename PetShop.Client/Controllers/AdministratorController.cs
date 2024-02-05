using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Services;

namespace PetShop.Controllers
{
    [Authorize(Roles = "Admins")]
    public class AdministratorController : Controller
    {
        private readonly IAnimalService _animalService;
        private readonly ICategoryService _categoryService;

        public AdministratorController(IAnimalService animalService, ICategoryService categoryService)
        {
            _animalService = animalService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Categories = await _categoryService.GetDistinctCategoriesAsync();

            return View(await _animalService.GetAllAnimalsAsync());
        }

        public async Task<IActionResult> Edit(int id)
        {
            var animal = await _animalService.GetAnimalByIdAsync(id);
            return RedirectToAction("Edit", "NewAnimal", animal);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var animal = await _animalService.GetAnimalByIdAsync(id);
            await _animalService.DeleteAnimalAsync(animal!);
            return RedirectToAction("Index", animal);
        }
    }
}
