using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Services;

namespace PetShop.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalService _animalService;
        private readonly ICommentService _commentService;
        private readonly ICategoryService _categoryService;

        public AnimalController(IAnimalService animalService, ICommentService commentService, ICategoryService categoryService)
        {
            _animalService = animalService;
            _commentService = commentService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int id)
        {
            var animal = await _animalService.GetAnimalByIdAsync(id);
            await PopulateViewData(animal!.CategoryId, id);
            return View(animal);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> AddComment(int id, string commentContent, string user)
        {
            var comment = new Comment() { AnimalId = id, Content = commentContent, UserName = user };

            if (ModelState.IsValid)
                await _commentService.AddCommentAsync(comment);

            return RedirectToAction("Index", new { id });
        }

        public async Task<IActionResult> DeleteComment(int id, int commentId)
        {
            var comment = await _commentService.GetCommentByIdAsync(commentId);

            await _commentService.DeleteCommentAsync(comment);
            return RedirectToAction("Index", new { id });
        }

        public async Task<IActionResult> EditComment(int id, int commentId, string newContent)
        {
            var comment = await _commentService.GetCommentByIdAsync(commentId);
            if (!string.IsNullOrWhiteSpace(newContent))
            {
                comment.Content = newContent;
                await _commentService.EditCommentAsync(comment);
                return RedirectToAction("Index", new { id });
            }

            // BadRequest
            return BadRequest("Comment can not be Empty!");
        }

        private async Task PopulateViewData(int categoryId, int animalId)
        {
            ViewBag.Category = await _categoryService.GetCategoryByCategoryIdAsync(categoryId);
            ViewBag.Comments = await _commentService.GetCommentsForAnimalAsync(animalId);
        }
    }
}
