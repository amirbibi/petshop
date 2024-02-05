using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services
{
    public interface IAnimalService
    {
        Task<IEnumerable<Animal>> GetAllAnimalsAsync();
        Task<IEnumerable<Animal>> GetAnimalsInCategoryIdAsync(int categoryId);
        Task<IEnumerable<Animal>> GetTopRatedAnimalsAsync(int top);
        Task<Animal?> GetAnimalByIdAsync(int animalId);
        Task InsertAnimalAsync(Animal animal);
        Task EditAnimalAsync(Animal updatedAnimal);
        Task DeleteAnimalAsync(Animal animal);
    }
}
