using Microsoft.AspNetCore.Mvc;
using PetShop.Services;

namespace PetShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnimalService _animalService;
        public HomeController(IAnimalService animalService)
        {
            _animalService = animalService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _animalService.GetTopRatedAnimalsAsync(2));
        }
    }
}
