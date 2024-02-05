using Microsoft.AspNetCore.Mvc;

namespace PetShop.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return Content("There was an unexpected error. Please come back later.");
        }

        [Route("Error/404")]
        public IActionResult Error404()
        {
            return View();
        }
    }
}
