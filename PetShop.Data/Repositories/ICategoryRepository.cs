using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Data.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetDistinctCategoriesAsync();
        Task<Category> GetCategoryByCategoryIdAsync(int categoryId);
    }
}
