using PetShop.Data.Repositories;
using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> GetCategoryByCategoryIdAsync(int categoryId)
        {
            return await _categoryRepository.GetCategoryByCategoryIdAsync(categoryId);
        }

        public async Task<IEnumerable<Category>> GetDistinctCategoriesAsync()
        {
            return await _categoryRepository.GetDistinctCategoriesAsync();
        }
    }
}
