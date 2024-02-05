using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Services;

namespace PetShop.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IAnimalService _animalService;
        private readonly ICategoryService _categoryService;

        public CatalogController(IAnimalService animalService, ICategoryService categoryService)
        {
            _animalService = animalService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Categories = await _categoryService.GetDistinctCategoriesAsync();

            return View(await _animalService.GetAllAnimalsAsync());
        }
    }
}
