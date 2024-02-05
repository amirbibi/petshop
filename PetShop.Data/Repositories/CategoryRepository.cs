using Microsoft.EntityFrameworkCore;
using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PetShopDbContext _context;

        public CategoryRepository(PetShopDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetDistinctCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByCategoryIdAsync(int categoryId)
        {
            return await _context.Categories.SingleAsync(c => c.CategoryId == categoryId);
        }
    }
}
